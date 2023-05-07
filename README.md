# InterestHub

Hämta alla personer => /getAllUsers

Hämta alla intressen som är kopplade till en specifik person => /getUser/{userId}

Hämta alla länkar som är kopplade till en specifik person => /getUserInterest/{userId}

Koppla en person till ett nytt intresse => /connectUserInterest 
body:
{
  "fK_UserId": 0,
  "fK_InterestId": 0
}

Lägga in nya länkar för en specifik person och ett specifikt intresse => /postLink
body:
{
  "title": "string",
  "url": "string"
} 

=> /connectUserLink
body:
{
  "fK_UserId": 0,
  "fK_InterestId": 0,
  "fK_LinkId": 0
}
