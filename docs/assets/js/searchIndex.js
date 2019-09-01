
var camelCaseTokenizer = function (builder) {

  var pipelineFunction = function (token) {
    var previous = '';
    // split camelCaseString to on each word and combined words
    // e.g. camelCaseTokenizer -> ['camel', 'case', 'camelcase', 'tokenizer', 'camelcasetokenizer']
    var tokenStrings = token.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
      var current = cur.toLowerCase();
      if (acc.length === 0) {
        previous = current;
        return acc.concat(current);
      }
      previous = previous.concat(current);
      return acc.concat([current, previous]);
    }, []);

    // return token for each string
    // will copy any metadata on input token
    return tokenStrings.map(function(tokenString) {
      return token.clone(function(str) {
        return tokenString;
      })
    });
  }

  lunr.Pipeline.registerFunction(pipelineFunction, 'camelCaseTokenizer')

  builder.pipeline.before(lunr.stemmer, pipelineFunction)
}
var searchModule = function() {
    var documents = [];
    var idMap = [];
    function a(a,b) { 
        documents.push(a);
        idMap.push(b); 
    }

    a(
        {
            id:0,
            title:"Gimei",
            content:"Gimei",
            description:'',
            tags:''
        },
        {
            url:'/api/DotGimei/Gimei',
            title:"Gimei",
            description:""
        }
    );
    a(
        {
            id:1,
            title:"GenderIdentity",
            content:"GenderIdentity",
            description:'',
            tags:''
        },
        {
            url:'/api/DotGimei/GenderIdentity',
            title:"GenderIdentity",
            description:""
        }
    );
    a(
        {
            id:2,
            title:"Address",
            content:"Address",
            description:'',
            tags:''
        },
        {
            url:'/api/DotGimei/Address',
            title:"Address",
            description:""
        }
    );
    a(
        {
            id:3,
            title:"IJapaneseText",
            content:"IJapaneseText",
            description:'',
            tags:''
        },
        {
            url:'/api/DotGimei/IJapaneseText',
            title:"IJapaneseText",
            description:""
        }
    );
    a(
        {
            id:4,
            title:"Name",
            content:"Name",
            description:'',
            tags:''
        },
        {
            url:'/api/DotGimei/Name',
            title:"Name",
            description:""
        }
    );
    a(
        {
            id:5,
            title:"Gimei Generator",
            content:"Gimei Generator",
            description:'',
            tags:''
        },
        {
            url:'/api/DotGimei/Generator',
            title:"Gimei.Generator",
            description:""
        }
    );
    a(
        {
            id:6,
            title:"JapaneseText",
            content:"JapaneseText",
            description:'',
            tags:''
        },
        {
            url:'/api/DotGimei/JapaneseText',
            title:"JapaneseText",
            description:""
        }
    );
    var idx = lunr(function() {
        this.field('title');
        this.field('content');
        this.field('description');
        this.field('tags');
        this.ref('id');
        this.use(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
        documents.forEach(function (doc) { this.add(doc) }, this)
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
