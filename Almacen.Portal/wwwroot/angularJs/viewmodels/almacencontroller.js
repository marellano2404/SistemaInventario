/// <reference path="../services/almacenmodel.js" />
/// <reference path="../globalapp.js" />
(function () {
    app.controller('almacenController', ['$scope', '$interval', function ($scope, $interval) {
        $scope.UsuarioViewModel = almacenContext.UsuarioViewModel;
        $scope.CargarDatosAlmacen = function () {
            var array = sessionStorage.getItem('datosUsuarioToken');
            $scope.UsuarioViewModel = JSON.parse(array);
            almacenContext.UsuarioViewModel = $scope.UsuarioViewModel; 
        };

    }]);
    app.filter('counter', [function () {
        return function (seconds) {
            return new Date(1970, 0, 1).setSeconds(seconds);
        };
    }]);
})();