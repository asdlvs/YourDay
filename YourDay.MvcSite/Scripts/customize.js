/**
 * Custom select control plugin
 */
(function( $ ) {

	var oCustomize = function( $element, options ){

		var that = this;

		var settings = jQuery.extend( {
			'className': 'customize-select-wrap'
			}, options || {} );

		this.init = function() {
			$( $element ).wrap( '<span class="' + settings.className + '"></span>' );
			this.$elementWrap = $( $element ).parent();
			
			this.$elementWrap.append( '<span class="element-value"></span>' );
			this.$elementValue = $( 'span.element-value', this.$elementWrap );

			var optionSelected = $( 'option:selected', $( $element ) ) || $( 'option:first-child', $( $element ) );
			this.$elementValue.text( optionSelected.text() );

			$( $element ).bind( 'change', this.change );
		}

		this.change = function() {
			that.$elementValue.text( $( 'option:selected', $( $element ) ).text() );
			/* any ajax calls if needed */
		}

		this.init();

	}

	$.fn.customize = function( options ) {
		return $( this ).each( function(){
			var item = new oCustomize( this, options );
			} );
	}

})( jQuery );