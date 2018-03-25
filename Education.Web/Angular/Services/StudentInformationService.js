educationApp.service("StudentInformationService", ['$http', '$rootScope', function ($http, $rootScope) {
   
    this.headers = $rootScope.headersWithLog;
    this.noLogHeaders = $rootScope.headersWithoutLog;
    //get All StudentInformation  
    this.getAllStudentInformations = function () {
        return $http({
            method: 'GET',
            url: api + "StudentInformation/GetAllStudentInformation",
          
            headers: this.noLogHeaders
        });
      
    };
    this.getStudentInformation = function (Id) {
        return $http({
            method: 'GET',
            url: api + 'StudentInformation/GetStudentInformation',
            params: {
                Id: Encrypt.encrypt(Id)
            },
            headers: this.noLogHeaders
        });
    };
    // Adding Record  
    this.AddNewStudentInformation = function (tbl_StudentInformation) {
        return $http({
            method: "post",
            url: api + "StudentInformation/AddStudentInformation",
            data: JSON.stringify(tbl_StudentInformation),
            headers: this.noLogHeaders,
            dataType: "json"
        });
    }
    // Updating record  
    this.UpdateStudentInformation = function (tbl_StudentInformation) {
        return $http({
            method: "post",
            url: api + "StudentInformation/UpdateStudentInformation",
            data: JSON.stringify(tbl_StudentInformation),
            headers: this.noLogHeaders,
            dataType: "json"
        });
    }
    // Deleting records  
    this.deleteStudentInformation = function (Id) {
        return $http({
            method: "POST",
            url: api + "StudentInformation/DeleteStudentInformation",
            params: {
                Id: Encrypt.encrypt(Id)
            },
            headers: this.noLogHeaders,
            dataType: "json"
        });
       
    }
    this.IsStudentInformationExists = function (name) {
       
        return $http({
            method: "GET",
            url: api + "StudentInformation/IsStudentInformationExists",
            params: {
                Name: Encrypt.encrypt(name)
            },
            headers: this.noLogHeaders,
            dataType: "json"
        });
       
    };
}]);