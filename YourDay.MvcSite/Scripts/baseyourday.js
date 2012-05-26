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

			var data = [
				{
					Title: 'Event 1',
					Link: 'http://yourday.com/events/1',
					Price: '20000',
					Description: 'Description 1',
					PublishDay: 'Вчера в 12.34',
					RequestCount: 12
				},
				{
					Title: 'Event 2',
					Link: 'http://yourday.com/events/2',
					Price: '30000',
					Description: 'Description 2',
					PublishDay: 'Сегодня в 12.34',
					RequestCount: 12
				}
			];
			
			/* Fake ajax call start */
//			$.ajax({
//				url: 'http://yourday.com/ajax/events/',
//				type: 'POST',
//				dataType: 'json',
//				success: function( data ) {
				
					$( '#tplEventItem' ).tmpl( data ).appendTo( '#listItems' );
				
//				}
//			});
			/* Fake ajax call end */
			
			return false;
			});

		$( 'select' ).customize();
	}
}