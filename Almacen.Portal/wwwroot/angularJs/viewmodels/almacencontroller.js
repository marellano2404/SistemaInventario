/// <reference path="../services/almacenmodel.js" />
/// <reference path="../globalapp.js" />
(function () {
    app.controller('almacenController', ['$scope', '$interval', function ($scope, $interval) {
        $scope.UsuarioViewModel = almacenContext.UsuarioViewModel;
        $scope.salidasAlmacenVM = almacenContext.salidasAlmacenVM; 
        $scope.ResultViewModel = almacenContext.ResultViewModel;
        $scope.CargarDatosAlmacen = function () {
            var array = sessionStorage.getItem('datosUsuarioToken');
            $scope.UsuarioViewModel = JSON.parse(array);
            almacenContext.UsuarioViewModel = $scope.UsuarioViewModel; 
            almacenContext.getSalidasAlmacen(0, function (res5) {
                if (res5.result === true) {
                    $scope.verListaSalidas = true;
                    $scope.verDetallesSalida = false;
                    $scope.salidasAlmacenVM = almacenContext.salidasAlmacenVM; 
                    
                    $scope.$apply();
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
        };
        $scope.verDetalleSalida = function (Salida) {            
            almacenContext.getdetalleSalidaAlmacen(Salida.folio, function (res1) {
                if (res1.result === true) {
                    localStorage.setItem("folioSalida", Salida.folio);
                    $scope.SalidaAlmacenSel = Salida;
                    $scope.DetalleSalidaVM = almacenContext.DetalleSalidaVM;
                    $scope.verDetallesSalida = true;
                    $scope.verListaSalidas = false;
                    $scope.$apply();
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
        };
        $scope.eliminarDetalleSalida = function (DetalleSalida) {            
            almacenContext.borrardetalleSalidaAlmacen(DetalleSalida.idSalidaAlmacen, function (res2) {
                if (res2.result === true) {
                    $scope.ResultViewModel = almacenContext.ResultViewModel;
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: $scope.ResultViewModel.mensaje,
                        icon: 'success',
                        confirmButtonText: 'OK'
                    });
                    var folioSalida = localStorage.getItem("folioSalida");
                    almacenContext.getdetalleSalidaAlmacen(folioSalida, function (res3) {
                        if (res3.result === true) {
                            $scope.SalidaAlmacenSel = Salida;
                            $scope.DetalleSalidaVM = almacenContext.DetalleSalidaVM;
                            $scope.verDetallesSalida = true;
                            $scope.verListaSalidas = false;
                            $scope.$apply();
                        }
                        else {
                            Swal.fire({
                                title: 'Mensaje del Sistema',
                                text: $scope.DetalleSalidaVM[0].mensaje,
                                icon: 'warning',
                                confirmButtonText: 'OK'
                            });
                        }
                    });
                    $scope.$apply();
                }
                else {
                    $scope.ResultViewModel = almacenContext.ResultViewModel;
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: $scope.ResultViewModel.mensaje,
                        icon: 'warning',
                        confirmButtonText: 'OK'
                    });
                }
            });
        };

    }]);
    app.filter('counter', [function () {
        return function (seconds) {
            return new Date(1970, 0, 1).setSeconds(seconds);
        };
    }]);
    app.filter('ctime', function ($filter) {
        return function (jsonDate) {
            if (jsonDate === null) { return ""; }
            var fecha = jsonDate.substring(6);
            var fechaString = new Date(parseInt(fecha));
            var mes = fechaString.getMonth() + 1;
            var dia = fechaString.getDate();
            var ano = fechaString.getFullYear();
            if (dia < 10) {
                dia = '0' + dia;
            }
            else {
                dia = dia;
            }

            if (mes < 10) {
                mes = '0' + mes;
            }
            else {
                mes = mes;
            }
            var fechaConversion = dia + "/" + mes + "/" + ano;
            return fechaConversion;
        };
    });
    app.filter('ctimeHora', function ($filter) {
        return function (jsonDate) {
            if (jsonDate === null) { return ""; }
            var fecha = jsonDate.substring(6);
            var fechaString = new Date(parseInt(fecha));
            var mes = fechaString.getMonth() + 1;
            var dia = fechaString.getDate();
            var ano = fechaString.getFullYear();
            var hora = fechaString.getHours();
            var minutes = fechaString.getMinutes();
            if (dia < 10) {
                dia = '0' + dia;
            }
            else {
                dia = dia;
            }

            if (mes < 10) {
                mes = '0' + mes;
            }
            else {
                mes = mes;
            }

            if (hora < 10) {
                hora = '0' + hora;
            }
            else {
                hora = hora;
            }

            if (minutes < 10) {
                minutes = '0' + minutes;
            }
            else {
                minutes = minutes;
            }

            var fechaConversion = dia + "/" + mes + "/" + ano + "| " + hora + ":" + minutes;
            return fechaConversion;
        };
    });
})();