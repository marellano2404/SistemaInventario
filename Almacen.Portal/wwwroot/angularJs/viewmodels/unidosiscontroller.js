/// <reference path="../services/unidosismodel.js" />
/// <reference path="../globalapp.js" />
(function () {
    app.controller('unidosisController', ['$scope', '$interval', function ($scope, $interval) {
        $scope.UsuarioViewModel = unidosisContext.UsuarioViewModel;
        $scope.CargarDatosAlmacen = function () {
            var array = sessionStorage.getItem('datosUsuarioToken');
            $scope.UsuarioViewModel = JSON.parse(array);
            unidosisContext.UsuarioViewModel = $scope.UsuarioViewModel;
        };

    }]);
    app.filter('counter', [function () {
        return function (seconds) {
            return new Date(1970, 0, 1).setSeconds(seconds);
        };
    }]);
})();