# .NET Core ile basit bir GraphQL API servisi

- Field: GraphType’mızın hangi propertylere sahip olacağının belirlendiği kısımdır.

- Arguments: Graphql isteğinden alınacak parametreler varsa bu kısımda tanımlanır.

- Resolve: Graphql’in döneceği data bu kısımda ayarlanır.
- 
- IDocumentExecuter: Graphql tarafında gelen queryi çalıştırmamız için gereklidir.

- ISchema: Gelen query için hangi şemayı kullanacağımızı belirlemek için gereklidir. (Startup da MarketingSchema inject edildi.)

- ExecutionOptions: Graphql tarafında queryi çalıştırırken gerekli olan ayarların yapıldığı kısımdır.

- FieldNameConverter: Bu kısım graphql queryimizin hangi standartta yazılması gerektiğini belirttiğimiz kısımdır.(Defaultta CamelCase dir.)

- Inputs: Querylerimizi hazırlarken, client tarafından istek atılırken ki variablesların tanımlanması için kullanılır.

 - Query: Çalışacak query.


Projeye eklemek için: 'dotnet add package GraphQL' yada Nugetpackage :https://www.nuget.org/packages/GraphQL

Örnek (Example) Query ;

 {
    "query":query{
        Products{
            Brand{
                Id
                Name
            }
            Title
        }
    }
}
