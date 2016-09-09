/* Task Description */
/* 
* Create a module for a Telerik Academy course
  * The course has a title and presentations
    * Each presentation also has a title
    * There is a homework for each presentation
  * There is a set of students listed for the course
    * Each student has firstname, lastname and an ID
      * IDs must be unique integer numbers which are at least 1
  * Each student can submit a homework for each presentation in the course
  * Create method init
    * Accepts a string - course title
    * Accepts an array of strings - presentation titles
    * Throws if there is an invalid title
      * Titles do not start or end with spaces
      * Titles do not have consecutive spaces
      * Titles have at least one character
    * Throws if there are no presentations
  * Create method addStudent which lists a student for the course
    * Accepts a string in the format 'Firstname Lastname'
    * Throws if any of the names are not valid
      * Names start with an upper case letter
      * All other symbols in the name (if any) are lowercase letters
    * Generates a unique student ID and returns it
  * Create method getAllStudents that returns an array of students in the format:
    * {firstname: 'string', lastname: 'string', id: StudentID}
  * Create method submitHomework
    * Accepts studentID and homeworkID
      * homeworkID 1 is for the first presentation
      * homeworkID 2 is for the second one
      * ...
    * Throws if any of the IDs are invalid
  * Create method pushExamResults
    * Accepts an array of items in the format {StudentID: ..., Score: ...}
      * StudentIDs which are not listed get 0 points
    * Throw if there is an invalid StudentID
    * Throw if same StudentID is given more than once ( he tried to cheat (: )
    * Throw if Score is not a number
  * Create method getTopStudents which returns an array of the top 10 performing students
    * Array must be sorted from best to worst
    * If there are less than 10, return them all
    * The final score that is used to calculate the top performing students is done as follows:
      * 75% of the exam result
      * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
*/

function solve() {
  let validator = {
    checkLength: function (str) {
      if (str.length < 1) {
        throw new Error();
      }
    },
    checkForSpaces: function (str) {
      if (str.indexOf(" ") === 0 || str.endsWith(" ")) {
        throw new Error();
      }
    },
    checkStudentName: function (name) {
      if (name[0].toLowerCase() === name[0]) {
        throw new Error();
      }

      if (name.substring(1).toLowerCase() !== name.substring(1)) {
        throw new Error();
      }
    },
    checkForConsecutiveSpaces: function (str) {
      let splitted = str.split(' ');
      if (splitted.length !== 2) {
        throw new Error();
      }
    }
  };

  let generator = {
    get: (function () {
      return (function () {
        var lastId = 0;
        return {
          getNext: function () {
            return lastId += 1;
          }
        };
      } ());
    })
  };

  let idGenerator = generator.get();

  let coursePresentations = [],
    students = [];;


  class Presentation {
    constructor(title) {
      this.title = title;
    }

    get title() {
      return this._title;
    }

    set title(x) {
      validator.checkLength(x);
      validator.checkForSpaces(x);
      validator.checkForConsecutiveSpaces(x);

      this._title = x;
    }
  }

  class Student {
    constructor(name) {
      this.id = idGenerator.getNext();
      validator.checkForConsecutiveSpaces(name);

      let names = name.split(' ');
      validator.checkStudentName(names[0]);
      validator.checkStudentName(names[1]);

      this.firstname = names[0];
      this.lastname = names[1];
    }
  }
  let init = function (title, presentations) {

    if (presentations.length === 0) {
      throw new Error();
    }

    validator.checkForSpaces(title);
    validator.checkLength(title);
    validator.checkForConsecutiveSpaces(title);

    presentations.forEach(function (element) {
      let presentation = new Presentation(element);
      coursePresentations.push(presentation);
    }, this);
  };



  let addStudent = function (name) {
    let newStudent = new Student(name);
    students.push(newStudent);

    return newStudent.id;
  }

  let getStudents = function () {
    let result = [];

    students.forEach(function (element) {
      let student = { firstname: element.firstname, lastname: element.lastname, id: element.id };
      result.push(student);
    }, this);

    return result;
  }

  let Course = {
    init: init,
    addStudent: addStudent,
    getAllStudents: getStudents,
    submitHomework: function (studentID, homeworkID) {
    },
    pushExamResults: function (results) {
    },
    getTopStudents: function () {
    }
  };

  return Course;
}


module.exports = solve;
