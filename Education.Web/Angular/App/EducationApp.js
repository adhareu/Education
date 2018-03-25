var api = "http://localhost:7764/api/";

var educationApp = angular.module("educationApp", ['ngMessages', 'datatables']);

educationApp.config(['$locationProvider', function ($locationProvider) {
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
}]);


var p;
var canvas = document.createElement("canvas");
var img1 = document.createElement("img");

function getBase64Image() {
   
    var imageData;
    var fileByteArray = [];
    //p = document.getElementById("file").value;
   
    var fileList = document.getElementById("file").files;
    var fileReader = new FileReader();
    if (fileReader && fileList && fileList.length) {
        fileReader.readAsArrayBuffer(fileList[0]);
       
             imageData = fileReader.result;
             array = new Uint8Array(imageData);
             for (var i = 0; i < array.length; i++) {
                 fileByteArray.push(array[i]);
             }
    }
   
    return fileByteArray;
    //img1.setAttribute('src', p);
    //canvas.width = img1.width;
    //canvas.height = img1.height;
    //var ctx = canvas.getContext("2d");
    //ctx.drawImage(img1, 0, 0);
    //var dataURL = canvas.toDataURL("image/png");
    
    //return dataURL;
}