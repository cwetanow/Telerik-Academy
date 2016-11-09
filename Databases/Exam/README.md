# Databases & SQL Practical Exam
_November 8, 2016_

## The exam should be submitted in https://telerikacademy.com before 21:30. There won't be any exceptions. You should submit `.zip` file with all the tasks. Without `bin`, `obj`, `packages` folders.

# _EntityFramework Code-first_
##  Task 1: SuperheroesUniverse: Database


- Use repository pattern for working with the data

- Create a application for storing superheroes:
  - Each superhero has **name**, **secret identity**, **city that protects**, **alignment** , **story**, a **list of fractions** and a **list of powers**
    - **name**:
      - Between **3** and **60** characters long
    - **secret identity**:
      - Between **3** and **20** characters long
      - Unique
    - **alignment**:
      - One of the following: `good`, `evil` or `neutral`
    - **story**:
      - A non-empty text
    - All properties are required
    - _Example:_
      - ("name": "Batman", secret identity: "Bruce Wayne", "city": "Gotham", "alignment": "good", "story": "After losing his parents...", "fractions": "Bat family", "Justice League", "powers": "Intelligence", "Utility belt")
  - Each power has a **name**
    - **name**:
      - Between **3** and **35** characters long
      - Unique
  - Each city has a **name** and **country**
    - **name**:
      - Between **2** and **30** characters long
      - Unique
  - Each country has a **"planet":**
    - **name**:
      - Between **2** and **30** characters long
      - Unique
  - Each "planet": has a **name**
    - **name**:
      - Between **2** and **30** characters long
      - Unique
  - Each fraction has a **name**, **alignment**, a **list of "planet":s** that it protects and a **list of members(superheroes)**
    - **name**:
      - Between **2** and **30** characters long
      - Unique
    - **alignment**:
      - On of the following: `good`, `evil` or `neutral`
    - _Examples:_
      - ("name": "Justice League", "alignment": "good", "planets": "Earth", "Oa", members: "Batman", "Superman", "Wonder woman", etc..)
      - ("name": "Green lantern Corps", "alignment": "good", "planets": "Oa", members: "John Stewart" , "Kilowog", "Hal Jordan")
  - Each couple of heroes can have a relationship
    - The relationships can be one of the following:
      - **Mortal enemies**, **Regular Enemies**, **Do not like each other**, **Teammates**, **Friends**, **Romantically involved**, **Indifferent**, **Not related at all**
    - _Examples:_
      - **Batman** and **The Joker** have a relationship **Mortal enemies**
      - **Batman** and **Ironman** can have either **Not related at all** or no relationship at all (They are from different universes)

Design the databases using EntityFramework and code-first approach

##  Task 2: SuperheroesUniverse: Importer

- By given information about planets, countries, cities, superheroes and their fractions, import the data correctly into the database
  - If any data is already in the database, use it, do not add a new entry
    - i.e. powers, cities, etc...
  - If a superhero already exists in the database, skip it
  - If the fraction does not exist it takes the alignment of the hero
  - The fraction should have the planet of the hero as part of its planets
  
- _Example JSON:_

```js
{
  "data": [
    {
      "name": "Batman",
      "secretIdentity": "Bruce Wayne",
      "city": {
        "name": "Gotham",
        "country": "USA",
        "planet": "Earth"
      },
      "alignment": "good",
      "story": "After losing his parents...",
      "powers": [ "Utility belt", "Intelligence", "Martial arts" ],
      "fractions": [ "Justice League", "The Bat Family" ]
    },
    {
      "name": "Dr. Stephen Strange",
      "secretIdentity": "Dr. Stephen Strange",
      "city": {
        "name": "New York",
        "country": "USA",
        "planet": "Earth"
      },
      "alignment": "good",
      "story": ".....",
      "powers": [ "Magic", "Multiverse travel", "Martial arts" ],
      "fractions": [ "Avengers", "Illuminati" ],
    },
    {
      "name": "The Joker",
      "secretIdentity": "Unknown",
      "city": {
        "name": "Gotham",
        "country": "USA",
        "planet": "Earth"
      },
      "alignment": "evil",
      "story": "Unknown",
      "powers": [ "Crazy", "Much evil" ],
      //no fractions
    },
    {
      "name": "Thanos",
      "secretIdentity": "Thanos",
      "city": {
        "name": "Unknown",
        "country": "Titan",
        "planet": "Saturn"
      },
      "alignment": "evil",
      "story": "Collects the infinity gems and creates the Infinity Gauntlet",
      "powers": [ "Super strength", "Telekinesis", "Telepathy", "Matter manipulation" ],
      //no fractions
    },
    {
      "name": "Deadpool",
      "secretIdentity": "Wade Wilson",
      "city": {
        "name": "Detroit",
        "country": "USA",
        "planet": "Earth"
      },
      "alignment": "evil",
      "story": "Collects the infinity gems and creates the Infinity Gauntlet",
      "powers": [ "Martial arts", "Healing" ],
      //no fractions
    }
  ]
}
```  

##  Task 3: SuperheroesUniverse: Queries

- Implement logic for exporting data to XML from the SuperheroesUniverse database
- Implement the following interface:

```cs
public interface ISuperheroesUniverseExporter {
  string ExportAllSuperheroes();

  string ExportSupperheroesWithPower(string power);

  string ExportSuperheroDetails(object superheroId);

  string ExportFractions();

  string ExportFractionDetails(object fractionId);

  string ExportSuperheroesByCity(string cityName);
}
```

- All of the methods must return valid XML as follows:
  - `string ExportAllSuperheroes();`

  ```xml
  <?xml version="1.0" encoding="UTF-8"?>
  <superheroes>
    <superhero id="1">
      <name>Batman</name>
      <secretIdentity>Bruce Wayne</secretIdentity>
      <alignment>Good</alignment>
      <powers>
        <power>Utility belt</power>
        <power>Intelligence</power>
        <power>Martial arts</power>
      </powers>
      <city>Gotham, USA, Earth</city>
    </superhero>
    <superhero id="13">
      <name>The Joker</name>
      <secretIdentity>Unknown</secretIdentity>
      <alignment>Evil</alignment>
      <powers>
        <power>Crazy</power>
        <power>Much evil</power>
      </powers>
      <city>Gotham, USA, Earth</city>
    </superhero>
    <superhero id="11">
      <name>Dr. Stephen Strange</name>
      <secretIdentity>Dr. Stephen Strange</secretIdentity>
      <alignment>Good</alignment>
      <powers>
        <power>Magic</power>
        <power>Multiverse travel</power>
        <power>Martial arts</power>
      </powers>
      <city>New York, USA, Earth</city>
    </superhero>
    ... more
  </superheroes>
  ```

- `string ExportAllSuperheroesWithPower(string power);`
  - The power is "Martial arts"

  ```xml
  <?xml version="1.0" encoding="UTF-8"?>
  <superheroes>
    <superhero id="1">
      <name>Batman</name>
      <secretIdentity>Bruce Wayne</secretIdentity>
      <alignment>Good</alignment>
      <powers>
        <power>Utility belt</power>
        <power>Intelligence</power>
        <power>Martial arts</power>
      </powers>
      <city>Gotham, USA, Earth</city>
    </superhero>
    <superhero id="11">
      <name>Dr. Stephen Strange</name>
      <secretIdentity>Dr. Stephen Strange</secretIdentity>
      <alignment>Good</alignment>
      <powers>
        <power>Magic</power>
        <power>Multiverse travel</power>
        <power>Martial arts</power>
      </powers>
      <city>New York, USA, Earth</city>
    </superhero>
  </superheroes>
  ```

- `string ExportSuperheroesByCity(string cityName);`
  - The city is "New York"

  ```xml
  <?xml version="1.0" encoding="UTF-8"?>
  <superheroes>
    <superhero id="111">
      <name>Ironman</name>
      <secretIdentity>Tonny Stark</secretIdentity>
      <alignment>Good</alignment>
      <city>New York, USA, Earth</city>
      <powers>
        <power>Mega powerful suit</power>
        <power>Intelligence</power>
      </powers>
    </superhero>
    <superhero id="11">
      <name>Dr. Stephen Strange</name>
      <secretIdentity>Dr. Stephen Strange</secretIdentity>
      <alignment>Good</alignment>
      <city>New York, USA, Earth</city>
      <powers>
        <power>Magic</power>
        <power>Multiverse travel</power>
        <power>Martial arts</power>
      </powers>
    </superhero>
  </superheroes>
  ```

  - `string ExportSuperheroDetails(object superheroId);`
    - The id is `11`

  ```xml
  <?xml version="1.0" encoding="UTF-8"?>
  <superhero id="11">
    <name>Dr. Stephen Strange</name>
    <secretIdentity>Dr. Stephen Strange</secretIdentity>
    <alignment>Good</alignment>
    <powers>
      <power>Magic</power>
      <power>Multiverse travel</power>
      <power>Martial arts</power>
    </powers>
    <fractions>
      <fraction id="17">Avengers</fraction>
      <fraction id="27">Illuminati</fraction>
    </fractions>
    <city>New York, USA, Earth</city>
    <story>.....</story>
  </superhero>
  ```

  - `string ExportFractions();`

  ```xml
  <?xml version="1.0" encoding="UTF-8"?>
  <fractions>
    <fraction id="27" membersCount="7">
      <name>Avengers</name>
      <planets>
        <planet>Earth</planet>
      </planets>
    </fraction>
      <fraction id="17" members="6">
        <name>Illuminati</name>
        <planets>
          <planet>Earth</planet>
        </planets>
      </fraction>
  </fractions>
  ```

  - `string ExportFractionDetails(object fractionId);`
    - The id is `17`

  ```xml
  <?xml version="1.0" encoding="UTF-8"?>
  <fraction id="17" membersCount="6">
    <name>Illuminati</name>
    <planets>
      <planet>Earth</planet>
    </planets>
    <members>
      <member id="11">
        Dr. Stephen Strange
      </member>
      <member id="16">
        Captain America
      </member>
      <member id="111">
        Ironman
      </member>
      <member id="57">
        Professor X
      </member>
      <member id="47">
        Black Panther
      </member>
    </members>
  </fraction>
  ```
# _EntityFramework Database first_
##  Task 4: Computers: Database

- Create a database for computers and computer configurations:
  - Each computer has a type ("Notebook", "Desktop" or "Ultrabook"), vendor, model, CPU, a list of GPUs, a list of storage devices and computer memory (RAM):
    - _Example:_

    ```js
    type:"Notebook", vendor: "Lenovo", model: "IdeaPad y700",
    CPU: "Intel Core i7-6700HQ", GPUs: "Intel HD Graphics 530", "NVIDIA GeForce GTX 980M",
    storage devices: "HDD 1 TB", "SSD 500 GB", Memory: '16 GB'
    ```

  - Each GPU has vendor, model, type (internal or external) and Memory

    - _Example:_

    ```js
    type: "external", vendor: "NVIDIA", model: "GTX 980M", memory: "4GB"
    ```

  - Each CPU has vendor, model, number of cores, clock cycles
    - _Example:_

    ```js
    vendor: "Intel", model: "Core i7 6700HQ", number of cores: "8", clock cycles: "2.6 GHz"
    ```

  - Each storage device has vendor, model, type ("SSD" or "HDD") and size:
    - _Example:_

    ```js
    vendor: "Samsung", model: "EVO M.2", type: "SSD", size: "500 GB"
    ```

Design a database using EntityFramework with database-first approach
**You should submit `.bak` file and `.sql` script with the schema only (without the data)**

##  Task 5: Computers: Sample data

- Fill the computers with some simple data:
  - At least 15 types of GPUs:
    - ~1/3 internal
    - ~2/3 external
  - At least 10 types of CPUs
  - At least 30 types of storage devices
    - ~1/4 SSD
    - ~3/4 HDD
  - At least 50 different computer configuration:
    - ~1/3 ultrabooks
    - ~1/3 notebooks
    - ~1/3 desktops

- Implement using EntityFramework with database-first approach

##  Task 6: Computers: Stored procedures

- Implement stored procedures for:
  - Returning all computers (vendor, model, id) with memory (RAM) between provided range
    - i.e. usp_GetComputersWithRamBetween(1 GB, 8 GB)
  - Returning all computers with a specific GPU (by id) and range of memory (as the above)
    - i.e. usp_GetComputersWithGpuAndRamBetween(2, 8 GB, 16 GB)
  - Return all GPUs that can be paired with a concrete computer type (dekstop, ultrabook or notebook)
    - i.e. usp_GetGpusForComputerType("ultrabook")

**Submit the stored procedures as `.sql` or text file or export them with the database** 
