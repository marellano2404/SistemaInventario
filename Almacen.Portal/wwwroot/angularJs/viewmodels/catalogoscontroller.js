/// <reference path="../services/catalogosmodel.js" />
/// <reference path="../globalapp.js" />
(function () {
    app.controller('catalogoController', ['$scope', '$interval', function ($scope, $interval) {
        $scope.UsuarioViewModel = catalogoContext.UsuarioViewModel;
        $scope.articulosVM = catalogoContext.ArticulosVM;
        $scope.articuloVM = catalogoContext.articuloVM;
        $scope.ResultViewModel = catalogoContext.ResultViewModel;
        $scope.totalRegistros = 10;
        $scope.paginaActual = 1;
        $scope.formUpdate = {};
        
        $scope.CargarArticulos = function () {
            var array = sessionStorage.getItem('datosUsuarioToken');
            $scope.UsuarioViewModel = JSON.parse(array);
            catalogoContext.UsuarioViewModel = $scope.UsuarioViewModel;
            var datos = {
                "total": $scope.totalRegistros,
                "paginaActual": $scope.paginaActual
            }
            catalogoContext.getArticulos(datos, function (response) {
                if (response.result === true) {
                    $scope.verListaArticulos = true;
                    $scope.articulosVM = catalogoContext.ArticulosVM;
                    let articulos = catalogoContext.ArticulosVM;
                    articulos.forEach((item) => {
                        let total = (item.cantidad / $scope.totalRegistros);
                        $scope.totalPaginas = Math.ceil(total);
                    });
                    console.log($scope.articulosVM)
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

            $scope.cerrarModal = function (modal) {
                if (modal == 1) {
                    $scope.verModalAgregar = false;
                    $scope.Modal = "";
                    $scope.$apply();
                } else {
                    $scope.verModalEditar = false;
                    $scope.Modal = "";
                    $scope.$apply();
                }
                
            };
            $scope.mostrarModalArticulo = function (modal, id = "") {
                if (modal == 1) {
                    $scope.verModalAgregar = true;
                    $scope.verModalEditar = false;
                   
                } else {
                    $scope.verModalAgregar = false;
                    $scope.verModalEditar = true;
                    $scope.editarArticulo(id);
                }
                $scope.Modal = urlPortal + "Catalogos/_AgregarArticulo";
                $scope.$apply();
            };
            // Métodos de la páginación
            $scope.Anterior = function() {
                $scope.paginaActual--;
                $scope.CargarArticulos();
            }
            $scope.Siguiente = function() {
                $scope.paginaActual++;
                $scope.CargarArticulos();
            }
            // final de métodos de paginación

            $scope.agregarArticulo = function(form) {
                console.log($scope.articuloVM)
                if (form) {
                    catalogoContext.postArticulos($scope.articuloVM, function (response) {
                        if (response.result === true) {
                            $scope.ResultViewModel = catalogoContext.ResultViewModel;
                            console.log($scope.ResultViewModel)
                            Swal.fire({
                                title: 'Mensaje del Sistema',
                                text: 'Se agrego correctamente el articulo!.',
                                icon: 'success',
                                confirmButtonText: 'Entendido'
                            });
                        }
                        else {
                            Swal.fire({
                                title: 'Mensaje del Sistema',
                                text: 'Hubo un detalle al agregar el articulo!.',
                                icon: 'warning',
                                confirmButtonText: 'Entendido'
                            });
                        }
                    });
                }
                else {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: 'Faltan datos por completar, verifique por favor.',
                        icon: 'warning',
                        confirmButtonText: 'Entendido'
                    });
                }
            }
            // llamar el metodo cuando se habrá el modal de edición.
            $scope.editarArticulo = function (id) {
                console.log(id);
                catalogoContext.getArticuloId(id, function (response) {
                    if (response.result === true) {
                        $scope.articuloVM = catalogoContext.ArticuloVM;
                        console.log($scope.articuloVM)
                    }
                    else {
                        Swal.fire({
                            title: 'Mensaje del Sistema',
                            text: 'Hubo un detalle al obtener el articulo!.',
                            icon: 'warning',
                            confirmButtonText: 'Entendido'
                        });
                    }
                });
            };

            $scope.modificarArticulo = function (form) {
                if (form) {
                    catalogoContext.putArticulos($scope.articuloVM, function (response) {
                        if (response.result === true) {
                            $scope.ResultViewModel = catalogoContext.ResultViewModel;
                            console.log($scope.ResultViewModel)
                        } else {
                            Swal.fire({
                                title: 'Mensaje del Sistema',
                                text: 'Hubo un detalle al modificar el articulo!.',
                                icon: 'warning',
                                confirmButtonText: 'Entendido'
                            });
                        }
                    });
                }
                else {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: 'Faltan datos por completar, verifique por favor.',
                        icon: 'warning',
                        confirmButtonText: 'Entendido'
                    });
                }
            };

            $scope.eliminarArticulo = function (id){
                Swal.fire({
                    title: 'Sistema',
                    text: "Estás seguro de eliminar el Articulo.?",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Si, eliminar..'
                }).then((result) => {
                    if (result.value) {
                        catalogoContext.deleteArticulos(id, function (response) {
                            if (response.result === true) {
                                $scope.ResultViewModel = catalogoContext.ResultViewModel;
                                console.log($scope.ResultViewModel);
                                $scope.CargarArticulos(); //refrescamos
                                if (result.value) {
                                    Swal.fire(
                                        'Sistema!',
                                        'El registro se ha eliminado correctamente.',
                                        'success'
                                    )
                                }
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
                    }
                    
                    
                })
            }

        };

    }]);


    app.filter('counter', [function () {
        return function (seconds) {
            return new Date(1970, 0, 1).setSeconds(seconds);
        };
    }]);
})();