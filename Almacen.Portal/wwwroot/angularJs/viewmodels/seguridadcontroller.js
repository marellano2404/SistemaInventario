/// <reference path="../services/seguridadmodel.js" />
/// <reference path="../globalapp.js" />
(function () {
    app.controller('seguridadController', ['$scope', '$interval', function ($scope, $interval) {
        $scope.UsuarioViewModel = seguridadContext.UsuarioViewModel;
        $scope.CargarDatosAlmacen = function () {
            var array = sessionStorage.getItem('datosUsuarioToken');
            $scope.UsuarioViewModel = JSON.parse(array);
            seguridadContext.UsuarioViewModel = $scope.UsuarioViewModel;
        };

    }]);
    app.filter('counter', [function () {
        return function (seconds) {
            return new Date(1970, 0, 1).setSeconds(seconds);
        };
    }]);
})();