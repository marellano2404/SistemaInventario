/// <reference path="../services/almacenmodel.js" />
/// <reference path="../globalapp.js" />
(function () {
    app.controller('almacenController', ['$scope', '$interval', function ($scope, $interval) {
        $scope.UsuarioViewModel = almacenContext.UsuarioViewModel;
        $scope.salidasAlmacenVM = almacenContext.salidasAlmacenVM; 
        $scope.ListaUnidades = almacenContext.ListaUnidades;
        $scope.ResultViewModel = almacenContext.ResultViewModel;
        $scope.ArticuloSalidaSel = almacenContext.ArticuloSalidaSel;
        $scope.Tipo = null;
        $scope.Valor = null;
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
                    localStorage.setItem("idSalidaSel", Salida.id);
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
        $scope.mostrarAddArticuloSalida = function () {
            $scope.verModal = true;
            $scope.Modal = urlPortal + "Almacen/_AgregarSalidaInventario";
            $scope.$apply();
        };
        $scope.buscarInventario = function (form) {
            if (form === true) {
                almacenContext.buscarArticuloInvetario(this.Tipo, this.Valor, function (res3) {
                    if (res3.result === true) {
                        $scope.ArticuloInventarioVM = almacenContext.ArticuloInventarioVM;                       
                        $scope.$apply();
                    }
                    else {
                        Swal.fire({
                            title: 'Mensaje del Sistema',
                            text: 'No se encontro ningun articulo con esos datos!',
                            icon: 'warning',
                            confirmButtonText: 'OK'
                        });
                    }
                });
            }
        };
        $scope.eliminarDetalleSalida = function (DetalleSalida) {            
            almacenContext.borrardetalleSalidaAlmacen(DetalleSalida.idSalidaAlmacen, function (res2) {
                if (res2.result === true) {
                    $scope.ResultViewModel = almacenContext.ResultViewModel;
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: 'Se ha eliminado correctamente su articulo',
                        icon: 'success',
                        confirmButtonText: 'OK'
                    });
                    var folioSalida = localStorage.getItem("folioSalida");
                    almacenContext.getdetalleSalidaAlmacen(folioSalida, function (res3) {
                        if (res3.result === true) {
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
        $scope.agregarArticuloSalida = function (form) {
            if (form === true) {
                var idSalidaAlmacenSel = localStorage.getItem("idSalidaSel");
                $scope.ArticuloSalidaSel.idSalidaAlmacen = idSalidaAlmacenSel;
                $scope.ArticuloSalidaSel.idInventario = $scope.ArticuloInventarioVM.idInventario;
                $scope.ArticuloSalidaSel.idArticulo = $scope.ArticuloInventarioVM.idArticulo;
                almacenContext.putSalidaAlmacen($scope.ArticuloSalidaSel, function (res5) {
                    if (res5.result === true) {
                        $scope.ResultViewModel = almacenContext.ResultViewModel;
                        if ($scope.ResultViewModel.exito === true) {
                            Swal.fire({
                                title: 'Mensaje del Sistema',
                                text: 'Se agrego correctamente el articulo!.',
                                icon: 'success',
                                confirmButtonText: 'OK'
                            });
                            var folioSalida = localStorage.getItem("folioSalida");
                            almacenContext.getdetalleSalidaAlmacen(folioSalida, function (res4) {
                                if (res4.result === true) {
                                    $scope.DetalleSalidaVM = almacenContext.DetalleSalidaVM;
                                    $scope.verModal = false;
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
                        }
                        else {
                            Swal.fire({
                                title: 'Mensaje del Sistema',
                                text: $scope.ResultViewModel.mensaje,
                                icon: 'warning',
                                confirmButtonText: 'OK'
                            });
                        }
                    }
                    else {
                        Swal.fire({
                            title: 'Mensaje del Sistema',
                            text: 'Hubo un detalle en la comunicación con el servidor.',
                            icon: 'warning',
                            confirmButtonText: 'OK'
                        });
                    }
                });
            }
            else
            {
                Swal.fire({
                    title: 'Mensaje del Sistema',
                    text: 'Ingrese Cantidad y tipo de Unidad',
                    icon: 'warning',
                    confirmButtonText: 'OK'
                });
            }
           
        };
        $scope.cerrarModal = function () {
            $scope.verModal = false;
            $scope.Modal = "";
            $scope.$apply();
        };
        $scope.finalizarSalida = function () {
            var idSalida = localStorage.getItem("idSalidaSel");
            almacenContext.cerrarSalidaAlmacen(idSalida, function (res4) {
                if (res4.result === true) {
                    //$scope.DetalleSalidaVM = almacenContext.DetalleSalidaVM;                    
                    $scope.verDetallesSalida = false;
                    $scope.verListaSalidas = true;
                    $scope.$apply();
                }
                else {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: 'Ocurrio un error en el guardado!.',
                        icon: 'warning',
                        confirmButtonText: 'OK'
                    });
                }
            });
        };
        $scope.crearReporte = function (SalidaDetalle) {

            var form = document.createElement("form");
            form.setAttribute("method", "post");
            form.setAttribute("action", "/Almacen/GenerarCedulaSalida");

            var Plantel = document.createElement("input");
            Plantel.setAttribute("type", "hidden");
            Plantel.setAttribute("name", "Plantel");
            Plantel.setAttribute("value", $scope.DatosCedulaInscripcion.plantel);
            //FechaInicio.setAttribute("value", 01-07-2019);
            var NombreCompleto = document.createElement("input");
            NombreCompleto.setAttribute("type", "hidden");
            NombreCompleto.setAttribute("name", "NombreCompleto");
            NombreCompleto.setAttribute("value", $scope.DatosCedulaInscripcion.nombres + ' ' + $scope.DatosCedulaInscripcion.apellidos);

            var Curp = document.createElement("input");
            Curp.setAttribute("type", "hidden");
            Curp.setAttribute("name", "Curp");
            Curp.setAttribute("value", $scope.DatosCedulaInscripcion.curp);

            var FichaExamen = document.createElement("input");
            FichaExamen.setAttribute("type", "hidden");
            FichaExamen.setAttribute("name", "FichaExamen");
            FichaExamen.setAttribute("value", $scope.DatosCedulaInscripcion.fichaExamen);

            var FechaOficio = document.createElement("input");
            FechaOficio.setAttribute("type", "hidden");
            FechaOficio.setAttribute("name", "fechaOficio");
            FechaOficio.setAttribute("value", $scope.DatosCedulaInscripcion.fecha_Operacion);

            var FechaNacimiento = document.createElement("input");
            FechaNacimiento.setAttribute("type", "hidden");
            FechaNacimiento.setAttribute("name", "fechaNacimiento");
            FechaNacimiento.setAttribute("value", $scope.DatosCedulaInscripcion.fechaNacimiento);


            var Sexo = document.createElement("input");
            Sexo.setAttribute("type", "hidden");
            Sexo.setAttribute("name", "Sexo");
            Sexo.setAttribute("value", $scope.DatosCedulaInscripcion.sexo);

            var Turno = document.createElement("input");
            Turno.setAttribute("type", "hidden");
            Turno.setAttribute("name", "Turno");
            Turno.setAttribute("value", $scope.DatosCedulaInscripcion.turno);

            form.appendChild(Plantel);
            form.appendChild(NombreCompleto);
            form.appendChild(Curp);
            form.appendChild(FichaExamen);
            form.appendChild(FechaOficio);
            form.appendChild(FechaNacimiento);
            form.appendChild(Sexo);
            form.appendChild(Turno);

            document.body.appendChild(form);
            form.submit();
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