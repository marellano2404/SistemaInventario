/// <reference path="../services/almacenmodel.js" />
/// <reference path="../globalapp.js" />
(function () {
    app.controller('almacenController', ['$scope', '$interval', '$http', function ($scope, $interval, $http) {
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
                        text: 'No se ha podido accesar a los datos, verifique.',
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
            console.log(SalidaDetalle);
            
            var form = document.createElement("form");
            form.setAttribute("method", "post");
            form.setAttribute("action", "/Almacen/GenerarSalidaAlmacen");

            var Clave = document.createElement("input");
            Clave.setAttribute("type", "hidden");
            Clave.setAttribute("name", "Clave");
            Clave.setAttribute("value", SalidaDetalle.claveProducto);
            //FechaInicio.setAttribute("value", 01-07-2019);
            var Descripcion = document.createElement("input");
            Descripcion.setAttribute("type", "hidden");
            Descripcion.setAttribute("name", "Descripcion");
            Descripcion.setAttribute("value", SalidaDetalle.descripcion);

            var TipoCatalogo = document.createElement("input");
            TipoCatalogo.setAttribute("type", "hidden");
            TipoCatalogo.setAttribute("name", "TipoCatalogo");
            TipoCatalogo.setAttribute("value", SalidaDetalle.tipoCatalogo);

            var ExistenciaUnidad = document.createElement("input");
            ExistenciaUnidad.setAttribute("type", "hidden");
            ExistenciaUnidad.setAttribute("name", "ExistenciaUnidad");
            ExistenciaUnidad.setAttribute("value", SalidaDetalle.existenciaUnidad);
        

            form.appendChild(Clave);
            form.appendChild(Descripcion);
            form.appendChild(TipoCatalogo);
            form.appendChild(ExistenciaUnidad);

            document.body.appendChild(form);
            form.submit();
        };
        $scope.verReporte = function (SalidadeAlmacen) {
            console.log(SalidadeAlmacen);
         
            var form = document.createElement("form");
            form.setAttribute("method", "post");
            form.setAttribute("action", "/Almacen/RptSalidaAlmacen");

            var Id = document.createElement("input");
            Id.setAttribute("type", "hidden");
            Id.setAttribute("name", "id");
            Id.setAttribute("value", SalidadeAlmacen.id);

            var Folio = document.createElement("input");
            Folio.setAttribute("type", "hidden");
            Folio.setAttribute("name", "folio");
            Folio.setAttribute("value", SalidadeAlmacen.folio);

            var Almacen = document.createElement("input");
            Almacen.setAttribute("type", "hidden");
            Almacen.setAttribute("name", "almacen");
            Almacen.setAttribute("value", SalidadeAlmacen.almacen);

            var Farmacia = document.createElement("input");
            Farmacia.setAttribute("type", "hidden");
            Farmacia.setAttribute("name", "farmacia");
            Farmacia.setAttribute("value", SalidadeAlmacen.farmacia);

            var Responsable = document.createElement("input");
            Responsable.setAttribute("type", "hidden");
            Responsable.setAttribute("name", "responsable");
            Responsable.setAttribute("value", SalidadeAlmacen.responsable);

            var FechaCaptura = document.createElement("input");
            FechaCaptura.setAttribute("type", "hidden");
            FechaCaptura.setAttribute("name", "fechaCaptura");
            FechaCaptura.setAttribute("value", SalidadeAlmacen.fechaCaptura);

            var FechaSalida = document.createElement("input");
            FechaSalida.setAttribute("type", "hidden");
            FechaSalida.setAttribute("name", "fechaSalida");
            FechaSalida.setAttribute("value", SalidadeAlmacen.fechaSalida);

            form.appendChild(Id);
            form.appendChild(Folio);
            form.appendChild(Almacen);
            form.appendChild(Farmacia);
            form.appendChild(Responsable);
            form.appendChild(FechaCaptura);
            form.appendChild(FechaSalida);

            document.body.appendChild(form);
            form.submit();   
        };
        $scope.CargarDatosSalidaAlmacen = function () {

            $scope.SalidaAlmacenSel.folio = "TUX10";
            $scope.$apply();
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