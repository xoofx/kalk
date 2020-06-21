Prism.languages.kalk = {
	'comment': [
		{
			pattern: /##(?:##)/,
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
	'class-name': [
        {
            pattern: /((?:class|module|struct|interface|extends|implements|instanceof|new)\s+)[A-Za-z_]\w*/,
            lookbehind: true,
            inside: {                
                'punctuation': /\./
            }
        },
		{
			// @Foo
			pattern: /(\@)[a-z_A-Z]\w*(?:\.\w+)*\b/,
			lookbehind: true,
			inside: {
				punctuation: /\./
			}
		}
    ],
	'keyword': /\b(?:if|else|end|for|in|case|when|while|break|continue|func|import|readonly|with|capture|ret|wrap|do)\b/,
    'number': /\b0x[\da-f]+\b|(?:\b\d+\.?\d*|\B\.\d+)(?:e[+-]?\d+)?/i,
    'function': /[\w_]+/,
	'variable': /[\w_]+/,
	'operator': /&\+-\*\:\=\?\!,\.<>;\[\]\{\}\|\\\/\(\)\^%@/,
	'punctuation': /\?\.?|::|[{}[\];(),.:]/    
};
