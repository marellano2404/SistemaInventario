/// <reference path="../services/alumnomodel.js" />
/// <reference path="../globalapp.js" />
(function () {
    app.controller('alumnoNgController', ['$scope','$interval', function ($scope, $interval) {
        this.alumno = alumnoContext.alumno;
        $scope.counter = 60; 
        $scope.TimeSesion = 0;
        $scope.Datosalumno = alumnoContext.Datosalumno;
        $scope.UsuarioViewModel = alumnoContext.UsuarioViewModel;
        $scope.verEgresados = false;
        $scope.ObtenerDatosAlumno = function () {
            $interval(function () {
                $scope.TimeSesion = $scope.counter--;
                if ($scope.TimeSesion == 0) {
                    alumnoContext.CerrarSesion(function (res) {
                        if (res.result === "ok") {
                            window.location.href = urlPortal + "Home/Login";
                        }
                        else {
                            window.location.href = urlPortal + "Home/Login";
                        }
                    });
                }
                console.log($scope.TimeSesion)
            }, 1000);
            var array = sessionStorage.getItem('datosAlumnoToken');
            $scope.UsuarioViewModel = JSON.parse(array);
            alumnoContext.UsuarioViewModel = $scope.UsuarioViewModel;            
            alumnoContext.verificaDatosAlumno($scope.UsuarioViewModel.idAlumno, function (res4) {                
                if (res4.result === false) {
                    $scope.verModal = true;
                    $scope.Modal = urlPortal + "Alumnos/_datosPrincipalesAlumno";
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: "Proporcione sus datos para guardarlo en su expediente.",
                        icon: 'info',
                        confirmButtonText: 'OK'
                    });
                    if ($scope.UsuarioViewModel.semestre === 6) {
                        $scope.verEgresados = true;
                    }
                }
                else {
                    if ($scope.UsuarioViewModel.semestre === 6) {
                        $scope.verEgresados = true;
                    }
                }               
                $scope.$apply();
            });
        };
        $scope.guardarDatosEntrada = function () {
            $scope.Datosalumno.IdAlumno = $scope.UsuarioViewModel.idAlumno;
            alumnoContext.guardarDatosEntrada($scope.Datosalumno, function (res3) {
                if (res3.result == true) {
                    $scope.verModal = false;
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: "Su datos fueron guardados exitosamente.",
                        icon: 'success',
                        confirmButtonText: 'OK'
                    });
                }
               $scope.$apply();
            });
        };
        $scope.CerrarSesion = function () {
            alumnoContext.CerrarSesion(function (res) {
                if (res.result === "ok") {
                    window.location.href = urlPortal + "Home/Login";
                }
                else {
                    window.location.href = urlPortal + "Home/Login";
                }
            });
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