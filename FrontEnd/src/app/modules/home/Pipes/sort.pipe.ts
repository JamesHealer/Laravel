import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'sort'
})
export class SortPipe implements PipeTransform {

  transform(value: any[], sortBy:string, sortOrder:string): unknown {
    if(value == null){
      return null;
    }
    value.sort(function(a,b){
      if(a[sortBy] && b[sortBy])
      {
        return a[sortBy].toString().toLowerCase()[0] - b[sortBy].toString().toLowerCase()[0]
      }else{
        return 0;
      }
    });
    if(sortOrder == 'DESC'){
      value.reverse();
    }
    return value;
  }

}
