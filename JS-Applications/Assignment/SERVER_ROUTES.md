# Server routes

## User routes

- `GET api/users`
  - **Returns** all users
  - _Example_:
    - **Request**:
      - No request body and/or headears
    - **Response**:

      ```js
      {
        "result": [{
            "id": "73a58989-5107-46e8-b781-4380f6c1c0b1",
            "username": "DonJoe"
          }, {
            "id": "27ee8e68-02e7-4228-b1d5-f7f20578e54f",
            "username": "stamat"
          }]
      }
      ```

-  `POST api/users`
  - **Registers** a new user
    - Needs **username** and **password** to be sent in the body of the request
    - Returns error response if user with the provided username is already registered
  - _Example_:
    - **Request**:      
      - Request body:

      ```js
      {
        "username": "johnnybravo",
        "password": "mypass123"
      }
      ```

    - **Response**:

    ```js
    {
      "result": {
        "username": "johnnybravo"
      }
    }
    ```

- `PUT api/users/auth/`
  - **Logs** in user
      - Needs **username** and **password** to be sent in the body of the request
      - If the request is valid returns **username** and **authKey**
      - Returns error response if:
        - User with the provided username is not registered
        - The password for the provided username does not match

  - _Example_:
    - **Request**:
      - Request body:

        ```js
        {
          "username": "johnnybravo",
          "password": "mypass123"
        }
        ```

    - **Response**:

      ```js
      {
        "result": {
          "username": "johnnybravo",
          "authKey": "TYKuz2GNYsn1GckC@GHzD1CTmLFm4RDshoy8ARq@"
        }
      }
      ```

  _Note_: The `authKey` is used for all non-public server routes

## Profile routes

- `GET api/profiles/:username`
  - **Returns** the user's profile details

  - _Example_:
    - **Request**:
      - No request body and/or headers
      - `:username` is replaced with a concrete username
        - Url: `api/profiles/DonchoMinkov`
    - **Response**:

      ```js
      {
        "result": {
          "username": "DonchoMinkov",
          "id": "73a58989-5107-46e8-b781-4380f6c1c0b1",
          "userMaterials": [{
              "id": "dd707118-fbb0-45e7-b95f-c4ee9c90a6c9",
              "title": "jQuery Fundamentals",
              "category": "want-to-watch"
            }, {
              "id": "bde2acbc-0bc2-43d2-a46a-4d3deb0eb7b3",
              "title": "JavaScript: Now and Then",
              "category": "want-to-watch"
            }]
        }
      }
      ```

## Materials routes

- `GET api/materials`
  - **Returns** all materials, sorted by `createdOn`
      - Can have query parameters:
        - `filter` - **search phrase**, the server will return **only the materials**, whose **description**, **title** or **author** contain the search phrase        
  - _Example 1 (without search phrase)_:
    - **Request**:
      - No request body and/or headers
    - Response

      ```js
      {
        "result": [{
            "id": "ffafd855-f6e8-480f-87f8-1ed61fb202fa",
            "title": "JavaScript Loops",
            "description": "loops, for, while, do-while",
            "createdOn": "2016-09-28T12:50:15.808Z",
            "img": "http://html5beginners.com/wp-content/uploads/2014/09/js.png",
            "commentsCount": 0,
            "user": {
              "id": "73a58989-5107-46e8-b781-4380f6c1c0b1",
              "username": "DonchoMinkov"
            }
          }, {
            "id": "4d7cc2dd-ef6c-4d26-939b-345ea9874a7f",
            "title": "We love ViM",
            "description": "...",
            "createdOn": "2016-09-28T12:50:15.763Z",
            "img": "https://www.planet-source-code.com/vb/2010Redesign/images/LangugeHomePages/HTML5_CSS_JavaScript.png",
            "commentsCount": 0,
            "user": {
              "id": "73a58989-5107-46e8-b781-4380f6c1c0c2",
              "username": "Cuklev"
            }
          }]
      }
      ```

  - _Example 2 (with search phrase)_:
    - **Request**:
      - No request body and/or headers
      - Query parameter for `filter` is added:
        - URL: `api/materials?filter=for`
    - **Response**:

      ```js
      {
        "result": [{
            "id": "ffafd855-f6e8-480f-87f8-1ed61fb202fa",
            "title": "JavaScript Loops",
            "description": "loops, for, while, do-while",
            "createdOn": "2016-09-28T12:50:15.808Z",
            "img": "http://html5beginners.com/wp-content/uploads/2014/09/js.png",
            "commentsCount": 0,
            "user": {
              "id": "73a58989-5107-46e8-b781-4380f6c1c0b1",
              "username": "DonchoMinkov"
            }
          }]
      }
      ```

- `POST api/materials`
  - Adds new material
    - Only authenticated users can add materials
    - Available only for authenticated users
    - Needs **title** and **description** in the body
    - Needs a `x-auth-key` header in the request
  - _Example_:
    - **Request**:
      - Request headers:
        - `x-auth-key: TYKuz2GNYsn1GckC@GHzD1CTmLFm4RDshoy8ARq@`
      - Request body:

        ```js
        {
          "title": "jQuery Fundamentals",
          "description": "Learn how to create magic-like stuff with jQuery",
          "img": "https://bitstorm.org/edwin/jquery-presentatie/pix/jquery_logo_color_onwhite.png" //optional
        }
        ```

    -   Response:

      ```js
      {
        "result": {
          "id": "2feae65a-7200-4223-90cd-dc246fe026a0",
          "title": "jQuery Fundamentals",
          "description": "Learn how to create magic-like stuff with jQuery",
          "createdOn": "2016-10-03T09:04:13.972Z",
          "img": "https://bitstorm.org/edwin/jquery-presentatie/pix/jquery_logo_color_onwhite.png",          
          "commentsCount": 0,
          "user": {
            "id": "27ee8e68-02e7-4228-b1d5-f7f20578e54f",
            "username": "johnnybravo"
          },
          "comments": []
        }
      }
      ```

- `GET api/materials/:id`
  - **Returns** the material with the provided id
  - _Example_:
    - **Request**:
      - No request body and/or headers
      - Add the id of the material in the place of `:id`
        - URL: `api/materials/2feae65a-7200-4223-90cd-dc246fe026a0`
    - **Response**:

      ```js
      {
        "result": {
          "id": "2feae65a-7200-4223-90cd-dc246fe026a0",
          "title": "jQuery Fundamentals",
          "description": "Learn how to create magic-like stuff with jQuery",
          "createdOn": "2016-10-03T09:04:13.972Z",
          "img": "https://bitstorm.org/edwin/jquery-presentatie/pix/jquery_logo_color_onwhite.png",          
          "commentsCount": 0,
          "user": {
            "id": "27ee8e68-02e7-4228-b1d5-f7f20578e54f",
            "username": "johnnybravo"
          },
          "comments": []
        }
      }
      ```

- `PUT api/materials/:id/comments`
  - Adds a comment to a material  
    - Available only for authenticated users
    - Needs **commentText** in the body  
    - Needs a `x-auth-key` header in the request

  - _Example_:
    - **Request**:  
      - Add the id of the material in the place of `:id`
        - URL: `api/materials/2feae65a-7200-4223-90cd-dc246fe026a0/comments`
      - Request headers:
        - `x-auth-key: TYKuz2GNYsn1GckC@GHzD1CTmLFm4RDshoy8ARq@`
      - Request body:       

        ```js
        {
        	"commentText":"This is great!"
        }
        ```

    - **Response**:

      ```js
      {
        "result": {
          "id": "2feae65a-7200-4223-90cd-dc246fe026a0",
          "title": "jQuery Fundamentals",
          "description": "Learn how to create magic-like stuff with jQuery",
          "createdOn": "2016-10-03T09:08:34.130Z",
          "commentsCount": 1,
          "user": {
            "id": "27ee8e68-02e7-4228-b1d5-f7f20578e54f",
            "username": "DonJoe"
          },
          "comments": [
            {
              "text": "This is great!",
              "user": {
                "id": "27ee8e68-02e7-4228-b1d5-f7f20578e54f",
                "username": "johnnybravo"
              }
            }
          ]
        }
      }
      ```

## User materials routes

- `GET api/user-materials`
  - **Returns** the materials, the logged-in user has added to a category
    - Available only for authenticated users
    - Needs a `x-auth-key` header in the request
  - _Example_:
    - **Request**:
      - No request body
      - Request headers:
        - `x-auth-key: QWGSXza@315gackCHGHzD1CTmLFm4RDshoy8ARq6`
    - **Response**:

      ```js
      {
        "result": [
          {
            "category": "watching",
            "title": "jQuery Fundamentals",
            "description": "jQuery Fundamentals",
            "createdOn": "2016-09-28T12:50:13.612Z",
            "commentsCount": 1,
            "user": {
              "id": "73a58989-5107-46e8-b781-4380f6c1c0b1",
              "username": "johnnybravo"
            },
            "id": "dd707118-fbb0-45e7-b95f-c4ee9c90a6c9"
          },
          {
            "category": "want-to-watch",
            "title": "We love Vim",
            "description": "...",
            "createdOn": "2016-09-28T12:50:13.679Z",
            "commentsCount": 0,
            "user": {
              "id": "73a58989-5107-46e8-b781-4380f6c1c0b1",
              "username": "johnnybravo"
            },
            "id": "bde2acbc-0bc2-43d2-a46a-4d3deb0eb7b3"
          }
        ]
      }
      ```



- `GET api/user-materials/watched`
  - **Returns** materials, the logged-in user has added to a category `watched`
    - Available only for authenticated users
  - _Example_:
    - **Request**:
      - No request body
      - Request headers:
        - `x-auth-key: QWGSXza@315gackCHGHzD1CTmLFm4RDshoy8ARq6`
    - **Response**:

      ```js
      {
        "result": [
          {
            "category": "watched",
            "title": "We love Vim",
            "description": "...",
            "createdOn": "2016-09-28T12:50:13.679Z",
            "commentsCount": 0,
            "user": {
              "id": "73a58989-5107-46e8-b781-4380f6c1c0b1",
              "username": "johnnybravo"
            },
            "id": "bde2acbc-0bc2-43d2-a46a-4d3deb0eb7b3"
          }
        ]
      }
      ```

- `GET api/user-materials/watching`
  - **Returns** materials, the logged-in user has added to a category `watching`
    - Available only for authenticated users
  - _Example_:
    - **Request**:
      - No request body
      - Request headers:
        - `x-auth-key: QWGSXza@315gackCHGHzD1CTmLFm4RDshoy8ARq6`
    - **Response**:

      ```js
      {
        "result": [          
          {
            "category": "watching",
            "title": "jQuery Fundamentals",
            "description": "jQuery Fundamentals",
            "createdOn": "2016-09-28T12:50:13.612Z",
            "commentsCount": 0,
            "user": {
              "id": "73a58989-5107-46e8-b781-4380f6c1c0b1",
              "username": "johnnybravo"
            },
            "id": "dd707118-fbb0-45e7-b95f-c4ee9c90a6c9"
          },
        ]
      }
      ```


- `GET api/user-materials/want-to-watch`
  - **Returns** materials, the logged-in user has added to a category `watching`
    - Available only for authenticated users
  - _Example_:
    - **Request**:
      - No request body
      - Request headers:
        - `x-auth-key: QWGSXza@315gackCHGHzD1CTmLFm4RDshoy8ARq6`
    - **Response**:

      ```js
      {
        "result": [          
          {
            "category": "want-to-watch",
            "title": "JS Now & then",
            "description": "History of JavaScript",
            "createdOn": "1989-06-22T12:50:13.612Z",
            "commentsCount": 0,
            "user": {
              "id": "73a58989-5107-46e8-b781-4380f6c1c0b1",
              "username": "DonchoMinkov"
            },
            "id": "dd707118-fbb0-45e7-b95f-c4ee9c90a6c9"
          },
        ]
      }
      ```


- `POST api/user-materials`
  - **Assign a category** to a material for the first time
    - Available only for authenticated users
  - _Example:_
    - **Request**:
      - Request headers:
        - `x-auth-key: QWGSXza@315gackCHGHzD1CTmLFm4RDshoy8ARq6`
      - Request body:

        ```js
        {
          "id": "bde2acbc-0bc2-43d2-a46a-4d3deb0eb7b3", //the id of the material
          "category": "want-to-watch" //the category, available are want-to-watch, watched and watching
        }
        ```

    - **Response**:

      ```js
      {
        "result": {
          "id": "bde2acbc-0bc2-43d2-a46a-4d3deb0eb7b3",
          "title": "We love ViM",
          "category": "want-to-watch"
        }
      }
      ```

- `PUT api/user-materials`
  - **Change the status** of a material
    - Available only for authenticated users
  - _Example:_
    - **Request**:
      - Request headers:
        - `x-auth-key: QWGSXza@315gackCHGHzD1CTmLFm4RDshoy8ARq6`
      - Request body:

        ```js
        {
          "id": "bde2acbc-0bc2-43d2-a46a-4d3deb0eb7b3", //the id of the material
          "category": "watched" //the category, available are want-to-watch, watched and watching
        }
        ```

    - **Response**:

      ```js
      {
        "result": {
          "id": "bde2acbc-0bc2-43d2-a46a-4d3deb0eb7b3",
          "title": "We love ViM",
          "category": "watched"
        }
      }
      ```
