myapp.controller("myController", function ($scope, Site) {
    baseEditController.call($scope, Site);
});


$(document).ready(function () {

    $("#products").kendoComboBox({
        placeholder: "请选择",
        dataTextField: "UserName",
        dataValueField: "Id",
        filter: "contains",
        index: 0,
        dataSource: {
            transport: {
                read: function (options) {
                    $.postJSON("/api/TestApi/GetList", { Page: 1, Pagesize: 10, Conditions: { _Equal__UserName: "ergaer", _Equal__IsAdmin: true } }).success(function (data) {
                        options.success(data);
                        console.log(data);
                    })
                    .error(function (data) {
                        options.error(data);
                        console.log(data);
                    });
                }
            }
        }
        //dataSource: {
        //    type: "odata",
        //    serverFiltering: true,
        //    transport: {
        //        read: {
        //            url: "http://demos.telerik.com/kendo-ui/service/Northwind.svc/Products",
        //        }
        //    },
        //    requestEnd: function (e) {
        //        e.response.d.results.unshift({ ProductID: '', ProductName: 'All' });
        //    }
        //}
    });
});