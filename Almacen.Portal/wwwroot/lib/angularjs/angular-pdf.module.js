import angular from 'angular';
import { NgPdf } from './angularjs/angular-pdf.directive'

export const Pdf = angular
  .module('pdf', [])
  .directive('ngPdf', NgPdf)
  .name;

export default Pdf;
