# CartApi---.Net-5


# Readme em construção 


comando para iniciar postgresql com docker:

docker run --name apiCart-postgres --network=postgres-network -e "POSTGRES_PASSWORD=Postgres2021!" -p 5432:5432  -d postgres

comando para iniciar Redis com Docker

docker run -d -p 6379:6379 --name redis1 redis

obs: em redis1 colocar o nome atribuido a imagem.


Cadastro de Categoria.

Post
Endpont : /api/menu/create-category

exemplo body: 

{

  "name": "nome da categoria",
  "isMain": true  // Referencia se é principal  ou não.
  
}

Cadastro de Sub Categoria:

Post
Endpoint: /api/menu/create-sub-category

ex body

{

  "name": "string",
  "categoryId": "3fa85f64-5717-4562-b3fc-2c963f66afa6" //Id da categoria cadastrada 
 
}

Listagem de Menu

GET
/api/menu/list-menu


Listagem das Principais Categorias : /api/menu/list-main-categories



Cadastro de Produtos:

POST
Endpoint: /api/product/create

Body esperado:

{
  "title": "Caderno Pautado Canson Escrita Azul Marinho A4+ 90g/m² com 80 folhas",
  "mark": "Canson",
  "color": "Azul Marinho",
  "size": "22.2 x 29.7cm",
  "description": "Marca Canson Numero do modelo : 7080019092931",
  "evaluation": 5,
  "price": 57.72,
  "subCategoryId": "9f83498f-31ed-47ec-a358-dd41c801949e",

  "images": [
    {
      "property": {
        "url": "www.images.com"
      }
    }
  ]
}


