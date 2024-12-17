# HovedOpgaveWebAPI
 
<p>Her kan du finde API specifikkationen and detaljerne på hvordan den fungere</p>

<h3>Generelle Bemærkninger:</h3>
<p>API'en kræver, at JSON-bodies er formateret korrekt.</p>
<p>Alle endpoints arbejder med GameData-tabellen, som har følgende felter: 
userId (string), 
gameId (string), 
body (string, ofte JSON-struktur).</p>
Sørg for, at userId og gameId altid er korrekt defineret i relevante requests.

<h3>Commands til at få det op at køre i docker:</h3>
* Download Git reppository
- Open folder with VSC or not just easier
- Run the following commands:
  - docker build -t hovedopgavewebapi . || docker build -t "NameOfImage" .  
  - docker run -d --network app-network -p 5134:5134 --name TestAPI hovedopgavewebapi || docker run -d --network app-network -p 5134:5134 --name "NameOfContainer" "NameOfImage"

Command to set up a new network bridge in docker
- docker network create -d bridge "network_name"

<div class="section">
    <h2>Endpoint 1: Get Data</h2>
    <p><strong>Description:</strong> Denne Endpoint henter alt data fra databasens GameData tabel.</p>


   <h3>Request</h3>
    
   <pre>
GET /api/Users/
    
    Response
    Status: 200 OK
      message [
      {
        "userId": 0,
        "gameId": 0,
        "body": "string"
      }
    ]

    Response
    Status: 200 OK
      message [
        {
          "userId": "1",
          "gameId": "1",
          "body": "{\"Chips\": 3, \"Money\": 150.5, \"Gender\": \"Male\", \"Volume\": 50, \"RewardNames\": [\"Reward1\", \"Reward2\"]}"
        },
        {
          "userId": "2",
          "gameId": "1",
          "body": "{\"Chips\": 5, \"Money\": 100.50, \"Gender\": \"Female\", \"Volume\": 10, \"RewardNames\": [\"Reward1\", \"Reward2\"]}"
        },
        {
          "userId": "2",
          "gameId": "2",
          "body": "{\"Gender\": \"Female\", \"Volume\": 10}"
        }
      ]
    
    Response
    Status: 400 BAD REQUEST
     (none)
    
    
    </pre>

   Explanation:

   I vores Database har vi en tabel vi henter data fra. Denne Tabel har 3 coloner: userUd, gameId, og body.
Når vi kalder en GET, så får vi en response med alle entitier i denne Tabel. Elementerne fra tabellen er i rækkefølge af userId. </div>

<div class="section">
    <h2>Endpoint 2: Get Data by User and Game IDs</h2>
    <p><strong>Description:</strong> Henter specifik data baseret på userId og gameId fra databasen.</p>


   <h3>Request</h3>
    
   <pre>
GET /api/Users/{userId}/{gameId}
   
   Example:  GET /api/Users/1/1

    Response
    Status: 200 OK
      message [
        {
          "userId": 1,
          "gameId": 1,
          "body": "{\"Chips\": 3, \"Money\": 150.5, \"Gender\": \"Male\", \"Volume\": 50, \"RewardNames\": [\"Reward1\", \"Reward2\"]}"
        }
    ]
    
    Response
    Status: 400 BAD REQUEST
     (none)

    Response
    Status: 404 NOT FOUND
     (none)
    
    
    </pre>

   Explanation:

   Returnerer data for en enkelt post fra GameData-tabellen baseret på både userId og gameId.</div>

<div class="section">
    <h2>Endpoint 3: Create User Data</h2>
    <p><strong>Description:</strong> Opretter en ny række i GameData-tabellen.</p>


   <h3>Request</h3>
    
   <pre>
POST /api/Users
   
   {
     "userId": "4",
     "gameId": "2",
     "body": "{\"Gender\": \"Male\", \"Volume\": 45}"
   }
    

    Response
    Status: 201 request successful
      message [
        {
          "userId": "4",
          "gameId": "2",
          "body": "{\"Gender\": \"Male\", \"Volume\": 45}"
        }
    ]
    
    Response
    Status: 400 BAD REQUEST
     (Hvis enten userId eller gameId mangler i body)

    Response
    Status: 409 Conflict
     (Hvis en post med samme userId og gameId allerede findes.)
    
    
    </pre>

   Explanation:

Opretter en ny post i databasen med de specificerede data. Kræver, at både userId og gameId er unikke.</div>

<div class="section">
    <h2>Endpoint 4: Put Data</h2>
    <p><strong>Description:</strong> Opdaterer eksisterende data for en given bruger og spil.</p>


   <h3>Request</h3>
    
   <pre>
PUT /api/Users/{userId}/{gameId}
   
   {
       "Updated body string"
   }
    Example:
   {
       "{\"Gender\": \"Male\", \"Volume\": 45, \"Money\": 40, \"Chips\": 500, \"RewardNames\": [\"RewardA\", \"RewardB\"]}"
   }

    Response
    Status: 204 request successful
      (Data opdateret med succes.)
    
    Response
    Status: 400 BAD REQUEST
     (none)

    Response
    Status: 404 NOT FOUND
     (Ingen post fundet med den specificerede userId og gameId.)

    Response
    Status: 500 Internal Server Error
     (none)
    
    
    </pre>

   Explanation:

Denne endpoint bruges til at opdatere body-feltet for en specifik kombination af userId og gameId.</div>


<div class="section">
    <h2>Endpoint 4: Delete User Data</h2>
    <p><strong>Description:</strong> Sletter en specifik række i databasen baseret på userId og gameId.</p>


   <h3>Request</h3>
    
   <pre>
DELETE /api/Users/{userId}/{gameId}
   
    Example:
       DELETE /api/Users/1/1
   

    Response
    Status: 204 request successful
      (Rækken er blevet slettet med succes.)

    Response
    Status: 404 NOT FOUND
     (Ingen post fundet med den specificerede userId og gameId.)
    
    
    </pre>

   Explanation:

Denne endpoint sletter en eksisterende post fra databasen baseret på userId og gameId..</div>


    
