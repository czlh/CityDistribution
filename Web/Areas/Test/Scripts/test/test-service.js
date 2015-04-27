myapp.factory("Site", function ($http) {
    return {
        name: "Test",
        area:"Test",
        baseUri: "/api/TestApi",
        getById: function (id) {
            return $http.get(this.baseUri + "/GetById", { params: { id: id } });
        },
        search: function (search) {
            return $http.post(this.baseUri + "/GetList", search);
        },
        getInstance:function(data){
            return $http.post(this.baseUri + "/GetInstance", data);
        },
        create: function (vm) {
            return $http.post(this.baseUri + "/Create", vm);
        },
        update: function (id,vm) {
            return $http.put(this.baseUri + "/Update/" + id, vm);
        },
        delete: function (id) {
            return $http.get(this.baseUri + "/delete/" + id);
        },
        deletes: function (ids) {
            return $http.get(this.baseUri + "/deletes/" + ids);
        }
    }
});