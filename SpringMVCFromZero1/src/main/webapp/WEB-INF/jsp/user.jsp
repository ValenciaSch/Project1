<%@ taglib uri="http://tiles.apache.org/tags-tiles" prefix="tiles" %>
<tiles:insertDefinition name="defaultTemplate">
    <tiles:putAttribute name="body">
        <div class="container">
            <div class="jumbotron">
                <h1>${current.name}'s Profile</h1>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title"> User</h3>
                        </div>
                        <div class="panel-body">
                            <div>Name:  ${current.name}</div>
                            <div>Email: ${current.email}</div>
                        </div>
                    </div>
                </div>

              
                        
                        
            </div>
        </div>
    </tiles:putAttribute>
</tiles:insertDefinition>