using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindOne.DrPipe.Dpf.Models
{
    public class DBMG_MEASURE_PS
    {

        [Key]
        [Column(Order = 0)]
		public string				KIND				{ get; set; }	
        [Key]
        [Column(Order = 1)]		
		public string				STA_FID				{ get; set; }	
		public string				MEASURE_NAME		{ get; set; }	
		public string				AREA_CD				{ get; set; }	
		public string				FLM_FID				{ get; set; }	
		public string				VRM_FID				{ get; set; }	
		public string				WPIP_FID			{ get; set; }	
		public double?				SIE					{ get; set; }	
		public double?				DIAM				{ get; set; }	
		public double?				GAUGE_ELEV			{ get; set; }	
		public string				FLOWGAGE_KIND		{ get; set; }	
		public double?				Q1					{ get; set; }	
		public double?				Q2					{ get; set; }	
		public double?				Q3					{ get; set; }	
		public double?				FLOWGAUGE_ERRRATE	{ get; set; }	
		public string				FLOWGAUGE_ISFIT		{ get; set; }	
		public DateTime?			FDAY				{ get; set; }	
		public DateTime?			TDAY				{ get; set; }	
		public DateTime?			RAWFDAY				{ get; set; }	
		public DateTime?			RAWTDAY				{ get; set; }	
		public double?				MINV				{ get; set; }	
		public double?				AVGV				{ get; set; }	
		public double?				MAXV				{ get; set; }	
		public byte[]				HAVE_DATA			{ get; set; }	
		public string				DESCRIPTION			{ get; set; }	

    }
}
