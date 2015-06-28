<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib uri="http://tiles.apache.org/tags-tiles" prefix="tiles" %>
<tiles:insertDefinition name="defaultTemplate">
    <tiles:putAttribute name="body">
        <div class="container">
            <div class="jumbotron">
                <h1>Clothing</h1>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Categories</h3>
                        </div>
                        <div class="panel-body">
                            <ul>
                                <a href="goods/all/1">For man </a> 
                            </ul>
                            <ul>
                                <a href="goods/all/2">For woman </a> 
                            </ul>
                        </div>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title"></h3>
                        </div>
                        <div class="panel-body">
                            <ul>
                                <c:forEach items="${goods}" var="good">
                                    <div>${good.name} - ${good.price}</div>
                                    <div> <img src="\SpringMVCFromZero1\ImageDB\${good.imege}" width='400' height='200' hspace='5' vspace='5' border = '1'></div>
                                </c:forEach>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </tiles:putAttribute>
</tiles:insertDefinition>

        
        
        
        
        
        
        
        <c:forEach items="${goods}" var="good">
            <div>${good.name} - ${good.price}</div>
        </c:forEach>
    </body>
</html>
