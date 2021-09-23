# Thesaurus

I have tried to use Onion Architecture in this project to achieve separation of converns pattern. My goal was to complete all 3 features.
But due to the lack of time I got, I could not provide test coverage for the project.

### Thesaurus Library
`Core`, `Infrastructure`

I used Graph-like structure for the data type. Each word is recorded as a Node in a Graph, and the synonymity is the Edge between two Nodes (words).
I defined the Service to query and create entries for the database.
I used `EntityFramework Core` for ORM. I used InMemoryDatabase to make testing the application easier.
#### Features:
- [x] Users are able to add a word with synonymity.
- [x] Users are able to get synonyms for a specific word.
- [x] Users are able to list all the words in thesaurus.
- [x] Library only allows lowercase keywords to be saved. (It saves all given words with their lowercase forms)
- [x] Library prevents creating duplicate word records. Instead it connects the existing ones with the new ones that are provided. For example:
      
      add("fast", ["rapid", "quick"])
      get("fast") => ["rapid", "quick"]
      add("fast", ["speedy"])
      get("fast") => ["rapid", "quick", "speedy"]

### Thesaurus Web API
`WebUI`

I created a Web API project with React for front-end side. I defined methods/endpoints for creating, querying, and searching for the entries in thesaurus.
It is basically a REST-ful API with an extra method for searching words.
#### Features:
- [x] endpoint for getting all entries.
- [x] endpoint for getting single entry with its synonyms.
- [x] endpoint for creating entries.
- [x] endpoint for searching entries with keyword.

### Thesaurus UI
`WebUI`

I used Reactjs for front-end application. Because I wanted to create a UI as fast as possible. React is the framework that I'm most confortable with.
#### Features:
- [x] Querying all the entries.
- [x] Searching for specific words.
- [x] Getting synonym words for selected words.
