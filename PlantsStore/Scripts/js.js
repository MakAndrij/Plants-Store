function showText (el) {
	if(el.previousElementSibling.clientHeight === 90) 
	{
		el.previousElementSibling.style.height = "100%";
		el.innerHTML = "Show Less";	
	}
	else
	{
		el.previousElementSibling.style.height = "90px";
		el.innerHTML = "Read More...";
	}
}