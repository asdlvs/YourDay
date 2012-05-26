/**
 * Base object
 */

var baseYourDay = {
	
	/**
	 * Events list page
	 */
	'catalog': function() {
		
		var $listItems = $( '#listItems' );
		var $listMore = $( '#listMore' );
		
		$listMore.bind( 'click', function(){

			/* Fake ajax call start */
			var clone = $listItems.html();
			$listItems.append( clone );
			/* Fake ajax call end */
			
			return false;
			});

		$( 'select' ).customize();
	}
}