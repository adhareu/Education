educationApp.controller("StudentInformationEditController", function ($scope,$location, StudentInformationService) {
    
    $scope.studentInformation = {};
    //Get Student INformation By Id
  
    var Id = $location.search()["id"];
    StudentInformationService.getStudentInformation(Id).then(function (response) {
       
        $scope.studentInformation = response.data;
    }).catch(function () { alert('Error in getting records'); });
  
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

   
});