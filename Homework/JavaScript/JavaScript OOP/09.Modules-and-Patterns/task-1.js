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
  var Course = (function () {
    const EXAM_PERCENTAGE_OF_FINAL_SCORE = 0.75;
    const HOMEWORK_PERCENTAGE_OF_FINAL_SCORE = 0.25;

    function validateTitle(title) {
      if (!title.length) {
        throw 'Title must be at least one symbol long.';
      } else if (title !== title.trim()) {
        throw 'Title cannot begin or end with a white space.';
      } else if (title.indexOf('  ') >= 0) {
        throw 'Title cannot contain consecutive white spaces.';
      }
    }

    function validateName(name) {
      if (name[0] !== name[0].toUpperCase()) {
        throw 'Student\'s names must begin with a capital letter.';
      } else {
        for (let i = 1; i < name.length; i += 1) {
          if (name[i] !== name[i].toLowerCase()) {
            throw 'Student\'s names must contain only ' +
            'lowercase letters except for the first one.';
          }
        }
      }
    }

    function validateId(id, bottomRange, topRange) {
      if (typeof id === 'undefined' || typeof id === 'undefined') {
        throw 'All required parameters must be provided!';
      } else if (id % 1 !== 0 || isNaN(id)) {
        throw 'IDs can only be integer values!';
      } else if (id < bottomRange || id > topRange) {
        throw `ID is out of range [${bottomRange} - ${topRange}]`;
      }
    }

    function getStudentById(students, id) {
      for (let student of students) {
        if (student.id === id) {
          return student;
        }
      }

      return -1;
    }

    function assignExamResultsToUnlistedStudents(students, examResults) {
      for (let student of students) {
        let isAdded = false;

        for (let examResult of examResults) {
          if (student.id === examResult.StudentID) {
            isAdded = true;
            break;
          }
        }

        if (!isAdded) {
          let studentResult = { StudentID: student.id, score: 0 };
          examResults.push(studentResult);
        }
      }
    }

    function assignFinalScoresToStudents(students, examResults, homeworks, totalHomeworks) {
      for (let result of examResults) {
        let student = getStudentById(students, result.StudentID);

        let homeworkScore = (homeworks[student.id] / totalHomeworks) || 0;
        let homeworkTotalScore = homeworkScore * HOMEWORK_PERCENTAGE_OF_FINAL_SCORE;
        let examTotalScore = result.score * EXAM_PERCENTAGE_OF_FINAL_SCORE;

        let finalScore = homeworkTotalScore + examTotalScore;

        student.finalScore = finalScore;
      }
    }

    function init(title, presentations) {
      if (!title || !presentations) {
        throw 'All required parameters must be provided.';
      }

      if (!presentations.length) {
        throw 'At least one presentation must be provided.';
      }

      validateTitle(title);
      presentations.forEach(p => validateTitle(p));

      this.uniqueStudentIdCounter = 0;

      this.title = title;
      this.presentations = presentations;
      this.students = [];
      this.homeworks = [];
      this.examResults = [];

      return this;
    }

    function addStudent(name) {
      if (!name) {
        throw 'Name must be provided';
      } else if (typeof name !== 'string') {
        throw 'Name must be a string.';
      }

      const EXPECTED_NAMES = 2;

      let studentNames = name.trim().split(' '),
        firstName = studentNames[0],
        lastName = studentNames[1];

      if (studentNames.length !== EXPECTED_NAMES) {
        throw 'Exactly two names, separated by a single white space, must be provided.';
      }

      validateName(firstName);
      validateName(lastName);

      let studentId = this.uniqueStudentIdCounter += 1;

      let student = {
        firstname: firstName,
        lastname: lastName,
        id: studentId,
        finalScore: null
      };

      this.students.push(student);

      return studentId;
    }

    function getAllStudents() {
      let allStudents = this.students.slice();

      return allStudents;
    }

    function submitHomework(studentID, homeworkID) {
      validateId(studentID, 1, this.students.length);
      validateId(homeworkID, 1, this.presentations.length);

      if (!this.homeworks[studentID]) {
        this.homeworks[studentID] = 1;
      } else {
        this.homeworks[studentID] += 1;
      }
    }

    function pushExamResults(results) {
      if (!results) {
        throw 'All required parameters must be provided!';
      } else if (typeof results !== 'object') {
        throw 'Results must be passed as an object.';
      }

      for (let result of results) {
        if (isNaN(result.score)) {
          throw 'Student score must be a number!';
        }

        validateId(result.StudentID, 1, this.students.length);

        for (let existingResult of this.examResults) {
          if (result.StudentID === existingResult.StudentID) {
            throw 'Cannot add the same student more than once!';
          }
        }

        this.examResults.push(result);
      }

      assignExamResultsToUnlistedStudents(this.students, this.examResults);
      assignFinalScoresToStudents(
        this.students,
        this.examResults,
        this.homeworks,
        this.presentations.length);
    }

    function getTopStudents() {
      let topStudents = this.students.sort((a, b) => b.finalScore - a.finalScore);

      return topStudents;
    }

    return {
      init,
      addStudent,
      getAllStudents,
      submitHomework,
      pushExamResults,
      getTopStudents,
    };
  } ());

  return Course;
}

module.exports = solve;