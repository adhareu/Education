educationApp.service("StudentAttendanceService", ['$http', '$rootScope', function ($http, $rootScope) {
   
    this.headers = $rootScope.headersWithLog;
    this.noLogHeaders = $rootScope.headersWithoutLog;
    //get All StudentAttendance  
    this.getAllStudentAttendances = function () {
        return $http({
            method: 'GET',
            url: api + "StudentAttendance/GetAllStudentAttendance",
          
            headers: this.noLogHeaders
        });
      
    };
    this.getStudentAttendance = function (Id) {
        return $http({
            method: 'GET',
            url: api + 'StudentAttendance/GetStudentAttendance',
            params: {
                Id: Encrypt.encrypt(Id)
            },
            headers: this.noLogHeaders
        });
    };
    // Adding Record  
    this.AddNewStudentAttendance = function (tbl_StudentAttendance) {
       
        return $http({
            method: "post",
            url: api + "StudentAttendance/AddStudentAttendance",
            data: JSON.stringify(tbl_StudentAttendance),
            headers: this.noLogHeaders,
            dataType: "json"
        });
    }
    // Updating record  
    this.UpdateStudentAttendance = function (tbl_StudentAttendance) {
        return $http({
            method: "post",
            url: api + "StudentAttendance/UpdateStudentAttendance",
            data: JSON.stringify(tbl_StudentAttendance),
            headers: this.noLogHeaders,
            dataType: "json"
        });
    }
    // Deleting records  
    this.deleteStudentAttendance = function (Id) {
        return $http({
            method: "POST",
            url: api + "StudentAttendance/DeleteStudentAttendance",
            params: {
                Id: Encrypt.encrypt(Id)
            },
            headers: this.noLogHeaders,
            dataType: "json"
        });
       
    }
    this.GetStudentAttendanceBydate = function (date) {
       
        return $http({
            method: "GET",
            url: api + "StudentAttendance/GetStudentAttendanceBydate",
            params: {
                date: Encrypt.encrypt(date)
            },
            headers: this.noLogHeaders,
            dataType: "json"
        });
       
    };
}]);