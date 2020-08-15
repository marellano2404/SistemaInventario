/// <reference path="../services/administradormodel.js" />
/// <reference path="../globalapp.js" />
(function () {
    app.controller('seguridadController', ['$scope','$interval', function ($scope, $interval) {
        $scope.MenuAdministrador = false;
        $scope.counter = 60; 
        $scope.TimeSesion = 0;
        $scope.Datosalumno = seguridadContext.Datosalumno;
        $scope.UsuarioViewModel = seguridadContext.UsuarioViewModel;
        $scope.verEgresados = false;
        $scope.cargarDatos = function () {           
            var array = sessionStorage.getItem('datosUsuarioToken');
            $scope.UsuarioViewModel = JSON.parse(array);
            seguridadContext.UsuarioViewModel = $scope.UsuarioViewModel;
            $scope.$apply();
        };

    }]);
    app.filter('counter', [function () {
        return function (seconds) {
            return new Date(1970, 0, 1).setSeconds(seconds);
        };
    }]);
    app.directive('withFloatingLabel', function () {
        return {
            restrict: 'A',
            link: function ($scope, $element, attrs) {
                var template = '<div class="floating-label">' + attrs.placeholder + '</div>';
                //append floating label template
                $element.after(template);
                //remove placeholder  
                $element.removeAttr('placeholder');
                //hide label tag assotiated with given input
                document.querySelector('label[for="' + attrs.id + '"]').style.display = 'none';

                $scope.$watch(function () {
                    if ($element.val().toString().length < 1) {
                        $element.addClass('empty');
                    } else {
                        $element.removeClass('empty');
                    }
                });
            }
        };
    });
    app.directive('passwordVerify', function () {
        return {
            require: 'ngModel',
            link: function (scope, elem, attrs, model) {
                if (!attrs.passwordVerify) {
                    console.error('passwordVerify espera un modelo como un argumento!');
                    return;
                }
                scope.$watch(attrs.passwordVerify, function (value) {
                    // Only compare values if the second ctrl has a value.
                    if (model.$viewValue !== undefined && model.$viewValue !== '') {
                        model.$setValidity('passwordVerify', value === model.$viewValue);
                    }
                });
                model.$parsers.push(function (value) {
                    // Mute the nxEqual error if the second ctrl is empty.
                    if (value === undefined || value === '') {
                        model.$setValidity('passwordVerify', true);
                        return value;
                    }
                    var isValid = value === scope.$eval(attrs.passwordVerify);
                    model.$setValidity('passwordVerify', isValid);
                    return isValid ? value : undefined;
                });
            }
        };
    });
})();