// Case of web-worker, we pre-initialize sql.js
if (typeof importScripts === 'function') {
    importScripts("lunet-sql-wasm.js");
}

class LunetSearch {
    constructor() {
	    performance.mark("lunet-search-start");
        this._available = false;
        this._reason = "Search not initialized";

        // configurable, should be properties 
        this.url_weight = 3.0;
        this.title_weight = 2.0;
        this.content_weight = 1.0;
        this.snippet_words = 20;
    }

    get available() {
        return this._available;
    }

    get reason()
    {
        return this._reason;
    }

    get perf() {
	    return this._perf;
    }

    _initializeDbFromResponse(sqlLoader, response, resolve) {
        const thisInstance = this;
        response.arrayBuffer().then((buffer) => {
            const u8Buffer = new Uint8Array(buffer);
            thisInstance._reason = "Please wait, initializing search engine...";
            sqlLoader.then((sql) => {
                this.db = new sql.Database(u8Buffer);
                try {
                    // fake exec to check if the database is valid
                    thisInstance.db.exec("pragma schema_version;");
                    thisInstance._available = true;
                    thisInstance._reason = "Search database available for queries.";

                    performance.mark("lunet-search-end");
                    thisInstance._perf = performance.measure("lunet-search-init",
                        "lunet-search-start",
                        "lunet-search-end");

                    resolve();
                } catch (err) {
                    thisInstance._reason = `Error while loading search database. ${err}`;
                }
            });
        });
    }

    initialize(dbUrl = "/js/lunet-search.db", locateSqliteWasm = (file) => `/js/lunet-${file}`)
    {
        const thisInstance = this;
        if ("caches" in self && "fetch" in self) {
            return new Promise(function(resolve, reject) {
                caches.open("lunet.cache").then((lunetCache) => {
                    const sqlLoader = self.lunetInitSqlJs({locateFile: function(file, prefix){ return locateSqliteWasm(file);} });
                    thisInstance._reason = "Please wait, initializing search database...";
                    // Always fecth the headers for the DB to check if we need to update it
                    fetch(dbUrl, { method: "HEAD" }).then((latestResponse) => {
                        lunetCache.match(dbUrl).then((cachedResponse) => {
                            var requiresFetch = false;
                            if (cachedResponse && cachedResponse.ok) {
                                var latestResponseLastModified = Date.parse(latestResponse.headers.get("Last-Modified"));
                                var cachedResponseLastModified = Date.parse(cachedResponse.headers.get("Last-Modified"));
                                // Check if the latest DB is more recent than the cached version
                                if (latestResponseLastModified > cachedResponseLastModified) {
                                    // console.log("Clearing db cache. latest: " + latestResponse.headers.get("Last-Modified") + " / current: " + cachedResponse.headers.get("Last-Modified"));
                                    requiresFetch = true;
                                } else {
                                    // We can use the cached version
                                    thisInstance._initializeDbFromResponse(sqlLoader, cachedResponse, resolve);
                                }
                            } else {
                                requiresFetch = true;
                            }

                            if (requiresFetch) {
                                fetch(dbUrl).then((latestResponse2) => {
                                    if (latestResponse2.ok) {
                                        // update cache
                                        lunetCache.put(dbUrl, latestResponse2);
                                        // refetch from cache
                                        lunetCache.match(dbUrl).then((cachedResponse2) => {
                                            thisInstance._initializeDbFromResponse(sqlLoader,
                                                cachedResponse2,
                                                resolve);
                                        });
                                    }
                                });
                            }
                        });
                    });
                });
            });
        } else {
            thisInstance._reason = "Browser does not support cache/fetch API required by search.";
            return new Promise(function(resolve, reject) { resolve() });
        }
    }

    query(text) {
        var thisInstance = this;
        if (!this.available) {
            return new Promise(function (resolve, failure) {
                failure(thisInstance.reason);
            });
        }
        else if (!text) {
            return new Promise(function (resolve, failure) {
                resolve([]);
            });
        }

        var escapeText = text.replace("'", " ");
        // Make sure that any " is closed by "
        if (((escapeText.match(/"/g) || []).length % 2) !== 0) {
            escapeText = escapeText + "\"";
        }
        var sqlQuery = `SELECT pages.url, pages.title, snippet(pages, 2, '<b>', '</b>', '', ${this.snippet_words}) FROM pages WHERE pages MATCH '${escapeText}' ORDER BY bm25(pages, ${this.url_weight}, ${this.title_weight}, ${this.content_weight});`;
        var results = [];

        try {
            const dbResults = this.db.exec(sqlQuery);
            if (dbResults.length > 0) {
                const rows = dbResults[0].values;
                for (let i = 0; i < rows.length; i++) {
                    const row = rows[i];
                    const url = row[0];
                    const title = row[1];
                    const snippet = row[2];

                    results.push({ url: url, title: title, snippet: snippet });
                }
            }
            return new Promise(function (resolve, failure) {
                resolve(results);
            });
        } catch (err) {
            return new Promise(function (resolve, failure) {
                failure(err);
            });
        }
    }
}

const DefaultLunetSearch = new LunetSearch();
const DefaultLunetSearchPromise = DefaultLunetSearch.initialize();

// Case of web-worker
if (typeof importScripts === 'function') {
    onmessage = function (e) {
        if (e.ports.length > 0 && e.data.command === "query") {
            DefaultLunetSearch.query(e.data.args).catch(err => {
                e.ports[0].postMessage({ reason: err });
            }).then(results => {
                e.ports[0].postMessage({results: results });
            });
        }
    };
}
