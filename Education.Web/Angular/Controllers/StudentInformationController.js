educationApp.controller("StudentInformationController", function ($scope, StudentInformationService, DTOptionsBuilder) {
    
    $scope.StudentInformation = {};
    $scope.StudentInformations = [];
  

   
    
    //To Get All Records  
  
       
    StudentInformationService.getAllStudentInformations().then(function (StudentInformation) {
            $scope.StudentInformations = StudentInformation.data;
        }).catch(function () {
            alert('Error in getting records');
        });
    
    $scope.IsStudentInformationExists = function () {
       
        StudentInformationService.IsStudentInformationExists($scope.StudentInformation.StudentName).then(function (response) {
           
            $scope.IsDuplicate= response.data;
        }).catch(function () { alert('Error in getting records'); });
    }
    //Get Student INformation By Id
    
    // Adding New student record  
    $scope.AddStudentInformation = function (StudentInformation) {
      
       
        var studentPic = getBase64Image();
        StudentInformation.Pic = studentPic;
        StudentInformationService.AddNewStudentInformation(StudentInformation).then(function (msg) {
            if (msg == true) {
                alert('Added Successfully');
                
            }
            
        }).catch( function () {
            alert('Error in adding record');
        });
    }
    // Deleting record.  
    $scope.deleteStudentInformation = function (StudentInformation, index) {
        var retval = StudentInformationService.deleteStudentInformation(StudentInformation.StudentId).then(function (msg) {
            
        }).catch(function () {
            alert('Oops! something went wrong.');
        });
    }
    // Updateing Records  
    $scope.UpdateStudentInformation = function (tbl_StudentInformation) {
        var studentPic = getBase64Image();
        StudentInformation.Pic = studentPic;
        var RetValData = StudentInformationService.UpdateStudentInformation(tbl_StudentInformation);
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