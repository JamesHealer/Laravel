import { Pipe, PipeTransform } from '@angular/core';
import { __values } from 'tslib';
import { FormTitleHd } from '../../models/formTitleHd';

@Pipe({
  name: 'filterLabels'
})
export class FilterLabelsPipe implements PipeTransform {

  transform(items: FormTitleHd[], searchTerm: string): any {

    if (items?.length === 0 || searchTerm === '') {
      return items
     } 
     let resultArray=[];
     for(let item of items)
     {
      if(String(item.headerName).toLowerCase().indexOf
      (searchTerm.toLowerCase()) >= 0){
        resultArray.push(item);
      }
     }
     return resultArray
     //else {
    //   return items.filter((item) => {
    //     return item.headerName.toLocaleLowerCase() === searchTerm.toLowerCase()
    //   })
    // }

    //const langId:number  = JSON.parse(localStorage.getItem('langType')!);
    // for(let i = 0; i < items.length; i++)
    // {  
    //   const values = items.filter(c=>c.labelId == searchTerm && c.language == langId );        
    //   return values;
    // }  

  }

}
