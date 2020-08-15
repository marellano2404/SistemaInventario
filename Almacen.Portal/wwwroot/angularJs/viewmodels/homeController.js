/// <reference path="../services/homemodel.js" />
/// <reference path="../globalapp.js" />
(function () {
    app.controller('homeController', ['$scope', '$interval', function ($scope, $interval){
        $scope.pdf = {
            scr: null,
            data: null
        };
        $scope.counter = 5400;
        $scope.pdfUrl = "";
        $scope.Usuarioview = homeContext.Usuarioview;
        $scope.ResultLoginViewModel = homeContext.ResultLoginViewModel;
        $scope.UsuarioViewModel = homeContext.UsuarioViewModel;

        $scope.banderaFicha = 0;
        const Toast = Swal.mixin({
            toast: true,
            position: 'center-end',
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true,
            onOpen: (toast) => {
                toast.addEventListener('mouseenter', Swal.stopTimer)
                toast.addEventListener('mouseleave', Swal.resumeTimer)
            }
        });
        //#region Inicio de Sesion    
        $scope.IniciarSesion = function (form) {
            if (form === true) {
                Toast.fire({
                    icon: 'info',
                    title: 'verificando datos de usuario, espere.......'
                });
                //window.location.href = urlPortal + "Home/Index";
                homeContext.autenticarUsuario($scope.Usuarioview, function (res5) {
                    if (res5.result === true) {
                        $scope.ResultLoginViewModel = homeContext.ResultLoginViewModel;
                        sessionStorage.setItem('datosUsuarioToken', JSON.stringify(homeContext.ResultLoginViewModel));
                        window.location.href = urlPortal + "Home/Index"; 
                    }
                    else {
                        Swal.fire({
                            title: 'Mensaje del Sistema',
                            text: $scope.ResultLoginViewModel.mensaje,
                            icon: 'warning',
                            confirmButtonText: 'OK'
                        });
                    }
                });
            }
            else {
                Swal.fire({
                    title: 'Mensaje del Sistema',
                    text: "Los datos estan incompletos",
                    icon: 'warning',
                    confirmButtonText: 'OK'
                });
            }
        };
        $scope.verificarUsuarioAlumno = function () {
            $scope.verModal = true;
            $scope.Modal = urlPortal + "Home/_recuperarPassword";
            Swal.fire({
                title: 'Mensaje del Sistema',
                text: "Proporcione sus datos para guardarlo en su expediente.",
                icon: 'info',
                confirmButtonText: 'OK'
            });
        };     
        //#endregion

        //#region inicio de Aspirante con Referencia de Pago
        $scope.CargarDatos = function () {
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
            $scope.Loading_ = true;
            $scope.VentanaModal = urlPortal + "home/_Loading";
            $scope.Mensaje_modal = "Verificando datos...";
            var array = sessionStorage.getItem('datosUsuarioToken');
            $scope.UsuarioViewModel = JSON.parse(array);
            aspiranteContext.UsuarioViewModel = $scope.UsuarioViewModel;

            $scope.$apply();
        };
        $scope.irRecibopago = function () {
            window.location.href = urlPortal + "CenevalAspirantes/RecibodePago";
        };
        $scope.irDatosAspirante = function () {
            window.location.href = urlPortal + "CenevalAspirantes/Registro";
        };
        $scope.irFichaExamen = function () {
            if ($scope.UsuarioViewModel.bandera === 4 || $scope.banderaFicha === 4) {
                window.location.href = urlPortal + "CenevalAspirantes/FichaExamen";
            }
            else {
                Swal.fire({
                    title: 'Mensaje del Sistema',
                    text: "Si su pago fué realizado, podrá acceder a su ficha, gracias!",
                    icon: 'info',
                    confirmButtonText: 'OK'
                });
            }         
        };

        //#endregion

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
    app.filter('counter', [function () {
        return function (seconds) {
            return new Date(1970, 0, 1).setSeconds(seconds);
        };
    }]);
})();