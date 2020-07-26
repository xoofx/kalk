var jstoc = document.getElementsByClassName("js-toc");
if (jstoc.length > 0)
{        
    tocbot.init({
        // Where to render the table of contents.
        tocSelector: '.js-toc',
        // Where to grab the headings to build the table of contents.
        contentSelector: '.js-toc-content',
        // Which headings to grab inside of the contentSelector element.
        headingSelector: 'h2, h3, h4, h5',
        collapseDepth: 3,
        orderedList: true,
    });
}

var searchBox = document.getElementById("search-box");
if (searchBox) {
    // Only add anchors if we have a search-box
    anchors.add(".kalk-doc h2");

    const lunetSearch = { noResults: "No results found" };
    $(searchBox).select2({
        multiple: true,
        width: '100%',
        placeholder: "Search... (Alt+s)",
        //dropdownAutoWidth: true,
        escapeMarkup: function (markup) { return markup; },
        language: {
            noResults: function () {
                return lunetSearch.noResults;
            }
        },
        ajax: {
            dataType: 'json',
            transport: function (params, success, failure) {
                if (!("term" in params.data) || params.data.term === "") {
                    lunetSearch.noResults = "Enter words to search...";
                    success({ results: [] });
                }
                else {
                    lunetSearch.noResults = "No results found.";
                    DefaultLunetSearch.query(params.data.term).then(rows => {
                        results = [];
                        for (let i = 0; i < rows.length; i++) {
                            var row = rows[i];
                            results.push({ id: i, text: `<a href='${row.url}'>${row.title}</a><div>${row.snippet}</div>`, url: row.url });
                        }
                        success({results: results});
                    }).catch(error => {
                        lunetSearch.noResults = error;
                        success({ results: [] });
                    });
                }
            }
        }
    });

    $(searchBox).on('select2:selecting', function (e) {
        e.preventDefault(); // Avoid the tags
        // Jump to the new location
        window.location = e.params.args.data.url;
    });

    document.onkeydown = function(e) {
        if (e.altKey && (e.key == "s" || e.key == "S"))
        {
            $(searchBox).select2('open');
            e.preventDefault(); // prevent the default action (scroll / move caret)
        }
    };
}

