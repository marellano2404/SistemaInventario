/// <reference path="../services/farmaciamodel.js" />
/// <reference path="../globalapp.js" />
(function () {
    app.controller('farmaciaController', ['$scope', '$interval', function ($scope, $interval) {
        $scope.UsuarioViewModel = farmaciaContext.UsuarioViewModel;
        $scope.CargarDatosAlmacen = function () {
            var array = sessionStorage.getItem('datosUsuarioToken');
            $scope.UsuarioViewModel = JSON.parse(array);
            farmaciaContext.UsuarioViewModel = $scope.UsuarioViewModel;
        };

    }]);
    app.filter('counter', [function () {
        return function (seconds) {
            return new Date(1970, 0, 1).setSeconds(seconds);
        };
    }]);
})();