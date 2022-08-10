# MongoDbProblem

How is it possible to add a field with unstructured data to a otherwise mapped domain class?
I get the error below.

If not - how is BsonDocument or any other clever solution anyway possible?
I always get JsonExceptions with BsonDocuments. 

Polymorphic classes are not a solution I can go for, as I have a ton of unstructured data variants possible for the UnstructuredInfo field. 


Postman/ThunderClient Get/Post...
```
http://localhost:5003/api/movies
```
Body:
```
{
  "id": null,
  "title": "test1",
  "year": 0,
  "summary": null,
  "actors": null,
  "unstructuredInfo": {
    "name": "MongoDB2",
    "type": "Database2",
    "count": 2,
    "info": {
      "x": 255,
      "y": 111
    }
  }
}
```


Null works ofc.
```
{
  "id": null,
  "title": "test1",
  "year": 0,
  "summary": null,
  "actors": null,
  "unstructuredInfo": null
}
```

```
Microsoft.AspNetCore.Http.BadHttpRequestException: Failed to read parameter "Movie movie" from the request body as JSON.
 ---> System.Text.Json.JsonException: The JSON value could not be converted to MongoDB.Bson.BsonDocument. Path: $.unstructuredInfo | LineNumber: 6 | BytePositionInLine: 23.
   at System.Text.Json.ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(Type propertyType)
   at System.Text.Json.Serialization.JsonCollectionConverter`2.OnTryRead(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options, ReadStack& state, TCollection& value)
   at System.Text.Json.Serialization.JsonConverter`1.TryRead(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options, ReadStack& state, T& value)
   at System.Text.Json.Serialization.Metadata.JsonPropertyInfo`1.ReadJsonAndSetMember(Object obj, ReadStack& state, Utf8JsonReader& reader)
   at System.Text.Json.Serialization.Converters.ObjectDefaultConverter`1.OnTryRead(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options, ReadStack& state, T& value)
   at System.Text.Json.Serialization.JsonConverter`1.TryRead(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options, ReadStack& state, T& value)
   at System.Text.Json.Serialization.JsonConverter`1.ReadCore(Utf8JsonReader& reader, JsonSerializerOptions options, ReadStack& state)
   at System.Text.Json.Serialization.JsonConverter`1.ReadCoreAsObject(Utf8JsonReader& reader, JsonSerializerOptions options, ReadStack& state)
   at System.Text.Json.JsonSerializer.ReadCore[TValue](JsonConverter jsonConverter, Utf8JsonReader& reader, JsonSerializerOptions options, ReadStack& state)
   at System.Text.Json.JsonSerializer.ReadCore[TValue](JsonReaderState& readerState, Boolean isFinalBlock, ReadOnlySpan`1 buffer, JsonSerializerOptions options, ReadStack& state, JsonConverter converterBase)
   at System.Text.Json.JsonSerializer.ContinueDeserialize[TValue](ReadBufferState& bufferState, JsonReaderState& jsonReaderState, ReadStack& readStack, JsonConverter converter, JsonSerializerOptions options)
   at System.Text.Json.JsonSerializer.ReadAllAsync[TValue](Stream utf8Json, JsonTypeInfo jsonTypeInfo, CancellationToken cancellationToken)
   at Microsoft.AspNetCore.Http.HttpRequestJsonExtensions.ReadFromJsonAsync(HttpRequest request, Type type, JsonSerializerOptions options, CancellationToken cancellationToken)
   at Microsoft.AspNetCore.Http.HttpRequestJsonExtensions.ReadFromJsonAsync(HttpRequest request, Type type, JsonSerializerOptions options, CancellationToken cancellationToken)
   at Microsoft.AspNetCore.Http.RequestDelegateFactory.<>c__DisplayClass46_3.<<HandleRequestBodyAndCompileRequestDelegate>b__2>d.MoveNext()
   --- End of inner exception stack trace ---
   at Microsoft.AspNetCore.Http.RequestDelegateFactory.Log.InvalidJsonRequestBody(HttpContext httpContext, String parameterTypeName, String parameterName, Exception exception, Boolean shouldThrow)
   at Microsoft.AspNetCore.Http.RequestDelegateFactory.<>c__DisplayClass46_3.<<HandleRequestBodyAndCompileRequestDelegate>b__2>d.MoveNext()
--- End of stack trace from previous location ---
   at Microsoft.AspNetCore.Routing.EndpointMiddleware.<Invoke>g__AwaitRequestTask|6_0(Endpoint endpoint, Task requestTask, ILogger logger)
   at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.Invoke(HttpContext context)
```
