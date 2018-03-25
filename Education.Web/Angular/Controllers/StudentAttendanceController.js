educationApp.controller("StudentAttendanceController", function ($scope, StudentAttendanceService,StudentInformationService, DTOptionsBuilder) {
    
    $scope.StudentAttendance = {};
    $scope.StudentAttendances = [];
    $scope.Students = {};

   
    
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