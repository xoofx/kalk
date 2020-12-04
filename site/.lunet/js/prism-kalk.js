Prism.languages.kalk = {
    'error': /^\u200B.*/m,
	'comment': [
		{
			pattern: /##.*(?:##|$)/,
			lookbehind: true
		},
		{
			pattern: /#.*/,
			lookbehind: true,
			greedy: true
		}
	],
	'string': [
        {
            pattern: /(["'])(?:\\(?:\r\n|[\s\S])|(?!\1)[^\\\r\n])*\1/,
            greedy: true
        },
        {
            pattern: /(`)(?:\1\1|\\[\s\S]|(?!\1)[^\\])*\1/,
            greedy: true
        },
        {
            pattern: /("|')(?:\\.|(?!\1)[^\\\r\n])*?\1/,
            greedy: true
        }
    ],
	'keyword': /\b(?:if|else|end|for|in|case|when|while|break|continue|func|import|readonly|with|capture|ret|wrap|do)\b/,
    'number': /\b0x[\da-f]+\b|(?:\b\d+\.?\d*|\B\.\d+)(?:e[+-]?\d+)?/i,
    'function': /[\w_]+/,
	'variable': /[\w_]+/,
	'operator': /&\+-\*\:\=\?\!,\.<>;\[\]\{\}\|\\\/\(\)\^%@/,
    'punctuation': /\?\.?|::|[{}[\];(),.:]/
};
