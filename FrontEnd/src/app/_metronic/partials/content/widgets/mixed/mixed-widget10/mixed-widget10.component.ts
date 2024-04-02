import { Component, Input, OnInit } from '@angular/core';
import { dashboardResponseDto } from 'src/app/modules/models/CommunicationDto';
import { DbCommonService } from 'src/app/modules/_services/db-common.service';
import { getCSSVariableValue } from '../../../../../kt/_utils';
@Component({
  selector: 'app-mixed-widget10',
  templateUrl: './mixed-widget10.component.html',
})
export class MixedWidget10Component implements OnInit {
  @Input() chartColor: string = '';
  @Input() chartHeight: string;
  chartOptions: any = {};
  totalEmp:number=0;
  lang: any = '';
lidashboardResponseDto:dashboardResponseDto[];
listTotalEmp: number[] = [];
listTotalMyperiod: string[] = [];
  constructor(private _commonService:DbCommonService) {

   this.lidashboardResponseDto=[];
   this.totalEmp=0;
  }

  ngOnInit(): void {
    this.getDashboardTotalEmployees();
    this.lang = localStorage.getItem('lang');
  }


  
  getDashboardTotalEmployees()
    {
      this._commonService.getDashboardTotalEmployees().subscribe((response:any)=>{
        this.lidashboardResponseDto=response;
        this.totalEmp=this.lidashboardResponseDto[0].myvalue2;
 
        this.chartOptions = this.getChartOptions(this.chartHeight, this.chartColor);

 
      });
  

    }

 

  getChartOptions(chartHeight: string, chartColor: string ) {
  const labelColor = getCSSVariableValue('--bs-gray-800');
  const strokeColor = getCSSVariableValue('--bs-gray-300');
  const baseColor = getCSSVariableValue('--bs-' + chartColor);
  const lightColor = getCSSVariableValue('--bs-light-' + chartColor);
  for (var s = 0; s < this.lidashboardResponseDto.length; s++) {

  //  this.listTotalEmp.push(s+30);
 
   this.listTotalEmp.push(this.lidashboardResponseDto[s].myvalue1);
  this.listTotalMyperiod.push(this.lidashboardResponseDto[s].myperiodcode);

  }

  var list: number[] = [];
  list = [...this.listTotalEmp];

  return {
    series: [
      {
        name: 'Employees',
        data:list,
      },
    ],
    chart: {
      fontFamily: 'inherit',
      type: 'area',
      height: chartHeight,
      toolbar: {
        show: false,
      },
      zoom: {
        enabled: false,
      },
      sparkline: {
        enabled: true,
      },
    },
    plotOptions: {},
    legend: {
      show: true,
    },
    dataLabels: {
      enabled: false,
    
    },
    fill: {
      type: 'solid',
      opacity: 1,
    },
    stroke: {
      curve: 'smooth',
      show: true,
      width: 3,
      colors: [baseColor],
    },
    xaxis: {
      categories: this.listTotalMyperiod,
     // categories: ['Feb', 'Mar', 'Apr'],
     
      axisBorder: {
        show: false,
      },
      axisTicks: {
        show: true,
      },
      labels: {
        show: true,
        style: {
          colors: labelColor,
          fontSize: '12px',
        },
      },
      crosshairs: {
        show: true,
        position: 'front',
        stroke: {
          color: strokeColor,
          width: 1,
          dashArray: 3,
        },
      },
      tooltip: {
        enabled: true,
      },
    },
    yaxis: {
       
      labels: {
        show: true,
        style: {
          colors: labelColor,
          fontSize: '12px',
        },
      },
    },
    states: {
      normal: {
        filter: {
          type: 'none',
          value: 0,
        },
      },
      hover: {
        filter: {
          type: 'none',
          value: 0,
        },
      },
      active: {
        allowMultipleDataPointsSelection: false,
        filter: {
          type: 'none',
          value: 0,
        },
      },
    },
    tooltip: {
      style: {
        fontSize: '12px',
      },
      y: {
        formatter: function (val: number) {
          return '' + val + ' Employees';
        },
      },
    },
    colors: [lightColor],
    markers: {
      colors: [lightColor],
      strokeColors: [baseColor],
      strokeWidth: 1,
    },
  };
}

}