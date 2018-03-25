educationApp.controller("StudentAttendanceEditController", function ($scope,$location, StudentAttendanceService,StudentInformationService, DTOptionsBuilder) {
    
    $scope.StudentAttendance = {};
    $scope.StudentAttendances = [];
    $scope.Students = {};

   
    var Id = $location.search()["id"];
    StudentAttendanceService.getStudentAttendance(Id).then(function (response) {

        $scope.studentInformation = response.data;
    }).catch(function () { alert('Error in getting records'); });
    //To Get All Records  
    StudentInformationService.getAllStudentInformations().then(function (StudentInformation) {
        $scope.Students = StudentInformation.data;
    }).catch(function () {
        alert('Error in getting records');
    });
       
    StudentAttendanceService.getAllStudentAttendances().then(function (StudentAttendance) {
            $scope.StudentAttendances = StudentAttendance.data;
        }).catch(function () {
            alert('Error in getting records');
        });
    
   
   
    
    // Adding New student record  
    $scope.AddStudentAttendance = function (StudentAttendance) {
      
       
    
        StudentAttendanceService.AddNewStudentAttendance(StudentAttendance).then(function (msg) {
            if (msg == true) {
                alert('Added Successfully');
                
            }
            
        }).catch( function () {
            alert('Error in adding record');
        });
    }
    // Deleting record.  
    $scope.deleteStudentAttendance = function (StudentAttendance, index) {
        var retval = StudentAttendanceService.deleteStudentAttendance(StudentAttendance.StudentId).then(function (msg) {
            
        }).catch(function () {
            alert('Oops! something went wrong.');
        });
    }
    // Updateing Records  
    $scope.UpdateStudentAttendance = function (tbl_StudentAttendance) {
       
        var RetValData = StudentAttendanceService.UpdateStudentAttendance(tbl_StudentAttendance);
        RetValData.then(function (msg) {
            if (msg == true)
                alert('Updated Successfully');
           
          
        }).catch( function () {
            alert('Error in getting records');
        });
    }

    $scope.dtOptions = DTOptionsBuilder.newOptions()
                .withPaginationType('full_numbers')
                .withDisplayLength(2);
});