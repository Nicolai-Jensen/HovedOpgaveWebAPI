# HovedOpgaveWebAPI
 
<p>Her kan du finde API specifikkationen and detaljerne på hvordan den fungere</p>

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
          "userId": 1,
          "gameId": 1,
          "body": "{\"Chips\": 3, \"Money\": 150.5, \"Gender\": \"Male\", \"Volume\": 50, \"RewardNames\": [\"Reward1\", \"Reward2\"]}"
        },
        {
          "userId": 2,
          "gameId": 1,
          "body": "{\"Chips\": 5, \"Money\": 100.50, \"Gender\": \"Female\", \"Volume\": 10, \"RewardNames\": [\"Reward1\", \"Reward2\"]}"
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
    <h2>Endpoint 2: Get Data by Id</h2>
    <p><strong>Description:</strong> Denne Endpoint henter specifik data fra databasens GameData tabel.</p>


   <h3>Request</h3>
    
   <pre>
GET /api/Users/{id}
   
   {
       "userId": 1     
   }
    

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
    
    
    </pre>

   Explanation:

   I vores Database har vi en tabel vi henter data fra. Denne Tabel har 3 coloner: userUd, gameId, og body.
Når vi kalder en GET {id}, så får vi en response for en enkelt element fra tabellen, den element man få matche userId til den indsatte værdi i kaldets body</div>

<div class="section">
    <h2>Endpoint 3: Post Data</h2>
    <p><strong>Description:</strong> Denne Endpoint laver en nye række som bruger</p>


   <h3>Request</h3>
    
   <pre>
GET /api/Users/{body}
   
   {
       \"Gender\": \"Male\", \"Volume\": 45, \"Money\": 40, \"Chips\": 500, \"RewardNames\": [\"2\", \"3\"] 
   }
    

    Response
    Status: 201 request successful
      message [
        {
          "userId": 4,
          "gameId": 1,
          "body": "{\"Gender\": \"Male\", \"Volume\": 45, \"Money\": 40, \"Chips\": 500, \"RewardNames\": [\"2\", \"3\"]}"
        }
    ]
    
    Response
    Status: 400 BAD REQUEST
     (none)

    Response
    Status: 500 Internal Server Error
     (none)
    
    
    </pre>

   Explanation:

Der man laver en POST request, så skal man ikke definere alle coloner. Den body man sender med i kaldet skal indeholde en jsonb, i vores tilfælde dele vi elementerne delte op med " \ ". Denne string SKAL indeholde disse backslash ellers får man endten en error 400 eller error 500
Man får tilbage ens lavet userId så man ved hvilken bruger man lige har lavet, der bliver også givet tilbage den jsonb man sendte så man også har dataen</div>

<div class="section">
    <h2>Endpoint 4: Put Data</h2>
    <p><strong>Description:</strong> Denne Endpoint opdatere en bruger række</p>


   <h3>Request</h3>
    
   <pre>
GET /api/Users/{id}
   
   {
       "userId": 4,
       "body": "{\"Gender\": \"Male\", \"Volume\": 80, \"Money\": 100, \"Chips\": 1000, \"RewardNames\": [\"2\", \"3\"]}"
   }

    Response
    Status: 200 OK
     (none)

    Response
    Status: 204 request successful
      (none)
    
    Response
    Status: 400 BAD REQUEST
     (none)

    Response
    Status: 400 NOT FOUND
     (none)

    Response
    Status: 500 Internal Server Error
     (none)
    
    
    </pre>

   Explanation:

Put requests kræver at context body indeholder en ID til useriD og en body til updateret data. Hvis det er gyldigt får man en response 200 for OK. Der bliver ikke hentede noget data i denne kald</div>


    
