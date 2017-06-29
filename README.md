# layered-solid-app   
Among the things worth mentioning about this project are the following:

- This is a multi-layered application that takes an API client as a Data Access Layer. 
- The singleton principle was applied for the HttpClient object.
- Communication between layers is via DTOs.
- Dependencies among clases were resolved via the Unity IoC container.
- Unit tests were performed on the Business Logic Layer with Nunit and Moq.
- The application was architected in a way that the business logic layer can be hooked with any Data Access Layer. It is not coupled with the API client currently in place.
- Same thing applies to the presentation layer, which in this particular project is an MVC website, but it could easily be replaced by WPF app, or an Angularjs, or literally any other component.


