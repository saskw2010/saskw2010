function onReady(yourMethod) {
    if (document.readyState === 'complete') { // Or also compare to 'interactive'
        setTimeout(yourMethod, 1); // Schedule to run immediately
    }
    else {
        readyStateCheckInterval = setInterval(function () {
            if (document.readyState === 'complete') { // Or also compare to 'interactive'
                clearInterval(readyStateCheckInterval);
                yourMethod();
            }
        }, 10);
    }
}

// Use like
onReady(function () {
    // var url = window.location.pathname;
    // var activePage = url.substring(url.lastIndexOf('/') + 1);
    // console.log(activePage);
    // activePage === '' ? $('#home').addClass("myactive") : $('#home').removeClass("myactive"); // for active index page
    // activePage === 'test.html' ? $('#about').addClass("myactive") : $('#about').removeClass("myactive"); //active about us
    // activePage === 'who-we-are' ? $('#info').addClass("myactive") : $('#info').removeClass("myactive");
    // var url1 = window.location.href;
    //$('.menu a[href="' + url1 + '"]').addClass(url1);
    //console.log(url1);
    //console.log('mostafa');
    //list = $('<ul data-inset="false" />');// document.querySelectorAll('.ui-listview > li.app-depth1');
    //console.log(list.className);
	
	var randomColor="";
	const listItems2 = document.querySelectorAll('.app-site-map >.ui-listview>li');
    for (let i = 0; i < listItems2.length; i++)
	{
    listItems2[i].className = listItems2[i].className + ' col-sm-6 ' + listItems2[i].textContent ;
    }
	const listItems3 = document.querySelectorAll('.app-site-map >.ui-listview>li>a');
    for (let i = 0; i < listItems3.length; i++) 
	{
        
		//randomColor = "#"+((1<<24)*Math.random()|0).toString(16);
		randomColor = "#"+ (2000000+(3000*i)).toString(16);
        listItems3[i].insertAdjacentHTML("beforeend", "<i  class='fas fa" + i + "'></i>");
        //listItems3[i].textContent//
    }
	
	
    const listItems1 = document.querySelectorAll('.app-page-menu>li');
    for (let i = 0; i < listItems1.length; i++)
	{
    listItems1[i].className = listItems1[i].className + ' col-sm-4 ' + listItems1[i].textContent ;
    }

    const listItems = document.querySelectorAll('.app-page-menu>li>a');
    for (let i = 0; i < listItems.length; i++) 
	{
        
		//randomColor = "#"+((1<<24)*Math.random()|0).toString(16);
		randomColor = "#"+ (6000000+(1000*i)).toString(16);
        listItems[i].insertAdjacentHTML("beforeend", "<i  class='fas fa" + i + "'></i>");
		// listItems[i].textContent      
        
    }



    

});