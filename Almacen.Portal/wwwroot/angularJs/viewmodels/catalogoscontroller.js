/// <reference path="../services/catalogosmodel.js" />
/// <reference path="../globalapp.js" />
(function () {
    app.controller('catalogoController', ['$scope', '$interval', function ($scope, $interval) {
        $scope.UsuarioViewModel = catalogoContext.UsuarioViewModel;
        $scope.CargarDatosAlmacen = function () {
            var array = sessionStorage.getItem('datosUsuarioToken');
            $scope.UsuarioViewModel = JSON.parse(array);
            catalogoContext.UsuarioViewModel = $scope.UsuarioViewModel;
        };

    }]);
    app.filter('counter', [function () {
        return function (seconds) {
            return new Date(1970, 0, 1).setSeconds(seconds);
        };
    }]);
})();