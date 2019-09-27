﻿//#region Copyright
///* The MIT License (MIT)

//Copyright (c) 2014 Anderson Luiz Mendes Matos (Brazil)

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in
//all copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//THE SOFTWARE.
//*/
//#endregion Copyright

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Xunit;
//using Moq;
//using Microsoft.AspNetCore.Mvc.ModelBinding;

//namespace DataTables.AspNet.AspNetCore.Tests
//{
//    /// <summary>
//    /// Represents tests for DataTables.AspNet.AspNet5 'RequestBinder' class.
//    /// </summary>
//    public class ModelBinderTests
//    {
//        /// <summary>
//        /// Validates CamelCase model binding with complete default DataTables values.
//        /// </summary>
//        [Fact]
//        public void CamelCase_CompleteValues()
//        {
//            // Arrange
//            var binder = new ModelBinder();
//            var modelBindingContext = TestHelper.MockModelBindingContextWithCamelCase("3", "13", "99", "mockSearchValue", "true");
//            var options = new Options();

//            // Act
//            //var model = (Core.IDataTablesRequest)binder.BindModel(modelBindingContext, options, TestHelper.ParseAdditionalParameters).Model;
//            binder.BindModel(modelBindingContext, options, TestHelper.ParseAdditionalParameters);
//            var model = modelBindingContext.Result.IsModelSet
//                ? (Core.IDataTablesRequest)modelBindingContext.Result.Model
//                : null;

//            // Assert
//            Assert.Equal(3, model.Draw);
//            Assert.Equal(13, model.Length);
//            Assert.Equal(99, model.Start);

//            Assert.Equal("mockSearchValue", model.Search.Value);
//            Assert.Equal(true, model.Search.IsRegex);

//            Assert.Equal(0, model.Columns.Count());
//        }
//        /// <summary>
//        /// Validates CamelCase model binding without draw parameter set and without draw validation.
//        /// </summary>
//        [Fact]
//        public void CamelCase_WithoutDrawWithoutValidation()
//        {
//            // Arrange
//            var binder = new ModelBinder();
//            var modelBindingContext = TestHelper.MockModelBindingContextWithCamelCase(null, "13", "99", "mockSearchValue", "true");
//            var options = new Options().DisableDrawValidation();

//            // Act
//            //var model = (Core.IDataTablesRequest)binder.BindModel(modelBindingContext, options, TestHelper.ParseAdditionalParameters).Model;
//            binder.BindModel(modelBindingContext, options, TestHelper.ParseAdditionalParameters);
//            var model = modelBindingContext.Result.IsModelSet
//                ? (Core.IDataTablesRequest)modelBindingContext.Result.Model
//                : null;

//            // Assert
//            Assert.Equal(0, model.Draw);
//            Assert.Equal(13, model.Length);
//            Assert.Equal(99, model.Start);
//            Assert.Equal("mockSearchValue", model.Search.Value);
//            Assert.Equal(true, model.Search.IsRegex);
//        }
//        /// <summary>
//        /// Validates CamelCase model binding without draw parameter set and with draw validation.
//        /// </summary>
//        [Fact]
//        public void CamelCase_WithoutDrawWithValidation()
//        {
//            // Arrange
//            var binder = new ModelBinder();
//            var modelBindingContext = TestHelper.MockModelBindingContextWithCamelCase(null, "13", "99", "mockSearchValue", "true");
//            var options = new Options();

//            // Act
//            //var model = (Core.IDataTablesRequest)binder.BindModel(modelBindingContext, options, TestHelper.ParseAdditionalParameters).Model;
//            binder.BindModel(modelBindingContext, options, TestHelper.ParseAdditionalParameters);
//            var model = modelBindingContext.Result.IsModelSet
//                ? (Core.IDataTablesRequest)modelBindingContext.Result.Model
//                : null;

//            // Assert
//            Assert.Equal(null, model);
//        }
//        /// <summary>
//        /// Validates CamelCase model binding with aditional parameters set and without enabling aditional parameters.
//        /// </summary>
//        [Fact]
//        public void CamelCase_WithAditionalParametersWithoutEnableAditionalParameters()
//        {
//            // Arrange
//            var binder = new ModelBinder();
//            var modelBindingContext = TestHelper.MockModelBindingContextWithCamelCase("3", "13", "99", "mockSearchValue", "true", new Dictionary<string, object>() { { "firstParameter", "firstValue" }, { "secondParameter", 7 } });
//            var options = new Options();

//            // Act
//            //var model = (Core.IDataTablesRequest)binder.BindModel(modelBindingContext, options, TestHelper.ParseAdditionalParameters).Model;
//            binder.BindModel(modelBindingContext, options, TestHelper.ParseAdditionalParameters);
//            var model = modelBindingContext.Result.IsModelSet
//                ? (Core.IDataTablesRequest)modelBindingContext.Result.Model
//                : null;

//            // Assert
//            Assert.Equal(3, model.Draw);

//            Assert.Equal(null, model.AdditionalParameters);
//        }
//        /// <summary>
//        /// Validates CamelCase model binding with aditional parameters set and with aditional parameters enabled.
//        /// </summary>
//        [Fact]
//        public void CamelCase_WithAditionalParametersWithEnableAditionalParameters()
//        {
//            // Arrange
//            var binder = new ModelBinder();
//            var modelBindingContext = TestHelper.MockModelBindingContextWithCamelCase("3", "13", "99", "mockSearchValue", "true", new Dictionary<string, object>() { { "firstParameter", "firstValue" }, { "secondParameter", 7 } });
//            var options = new Options().EnableRequestAdditionalParameters();

//            // Act
//            //var model = (Core.IDataTablesRequest)binder.BindModel(modelBindingContext, options, TestHelper.ParseAdditionalParameters).Model;
//            binder.BindModel(modelBindingContext, options, TestHelper.ParseAdditionalParameters);
//            var model = modelBindingContext.Result.IsModelSet
//                ? (Core.IDataTablesRequest)modelBindingContext.Result.Model
//                : null;

//            // Assert
//            Assert.Equal(3, model.Draw);

//            Assert.Equal("firstValue", model.AdditionalParameters["firstParameter"]);
//            Assert.Equal(7, model.AdditionalParameters["secondParameter"]);
//        }



//        /// <summary>
//        /// Validates HungarianNotation model binding with complete default DataTables values.
//        /// </summary>
//        [Fact]
//        public void HungarianNotation_CompleteValues()
//        {
//            // Arrange
//            var binder = new ModelBinder();
//            var modelBindingContext = TestHelper.MockModelBindingContextWithHungarianNotation("3", "13", "99", "mockSearchValue", "true");
//            var options = new Options().UseHungarianNotation();

//            // Act
//            //var model = (Core.IDataTablesRequest)binder.BindModel(modelBindingContext, options, TestHelper.ParseAdditionalParameters).Model;
//            binder.BindModel(modelBindingContext, options, TestHelper.ParseAdditionalParameters);
//            var model = modelBindingContext.Result.IsModelSet
//                ? (Core.IDataTablesRequest)modelBindingContext.Result.Model
//                : null;

//            // Assert
//            Assert.Equal(3, model.Draw);
//            Assert.Equal(13, model.Length);
//            Assert.Equal(99, model.Start);

//            Assert.Equal("mockSearchValue", model.Search.Value);
//            Assert.Equal(true, model.Search.IsRegex);

//            Assert.Equal(0, model.Columns.Count());
//        }
//        /// <summary>
//        /// Validates HungarianNotation model binding without draw parameter set and without draw validation.
//        /// </summary>
//        [Fact]
//        public void HungarianNotation_WithoutDrawWithoutValidation()
//        {
//            // Arrange
//            var binder = new ModelBinder();
//            var modelBindingContext = TestHelper.MockModelBindingContextWithHungarianNotation(null, "13", "99", "mockSearchValue", "true");
//            var options = new Options().UseHungarianNotation().DisableDrawValidation();

//            // Act
//            //var model = (Core.IDataTablesRequest)binder.BindModel(modelBindingContext, options, TestHelper.ParseAdditionalParameters).Model;
//            binder.BindModel(modelBindingContext, options, TestHelper.ParseAdditionalParameters);
//            var model = modelBindingContext.Result.IsModelSet
//                ? (Core.IDataTablesRequest)modelBindingContext.Result.Model
//                : null;

//            // Assert
//            Assert.Equal(0, model.Draw);
//            Assert.Equal(13, model.Length);
//            Assert.Equal(99, model.Start);
//            Assert.Equal("mockSearchValue", model.Search.Value);
//            Assert.Equal(true, model.Search.IsRegex);
//        }
//        /// <summary>
//        /// Validates HungarianNotation model binding without draw parameter set and with draw validation.
//        /// </summary>
//        [Fact]
//        public void HungarianNotation_WithoutDrawWithValidation()
//        {
//            // Arrange
//            var binder = new ModelBinder();
//            var modelBindingContext = TestHelper.MockModelBindingContextWithHungarianNotation(null, "13", "99", "mockSearchValue", "true");
//            var options = new Options().UseHungarianNotation();

//            // Act
//            //var model = (Core.IDataTablesRequest)binder.BindModel(modelBindingContext, options, TestHelper.ParseAdditionalParameters).Model;
//            binder.BindModel(modelBindingContext, options, TestHelper.ParseAdditionalParameters);
//            var model = modelBindingContext.Result.IsModelSet
//                ? (Core.IDataTablesRequest)modelBindingContext.Result.Model
//                : null;

//            // Assert
//            Assert.Equal(null, model);
//        }
//        /// <summary>
//        /// Validates invalid (not-DataTables) request model binding.
//        /// </summary>
//        [Fact]
//        public void InvalidRequest()
//        {
//            // Arrange
//            var binder = new ModelBinder();
//            var modelBindingContext = TestHelper.MockModelBindingContextWithInvalidRequest();
//            var options = new Options();

//            // Act
//            //var model = (Core.IDataTablesRequest)binder.BindModel(modelBindingContext, options, TestHelper.ParseAdditionalParameters).Model;
//            binder.BindModel(modelBindingContext, options, TestHelper.ParseAdditionalParameters);
//            var model = modelBindingContext.Result.IsModelSet
//                ? (Core.IDataTablesRequest)modelBindingContext.Result.Model
//                : null;

//            // Assert
//            Assert.Equal(null, model);
//        }
//    }
//}
