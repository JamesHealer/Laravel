import { NgModule } from "@angular/core";
import { FilterLabelsPipe } from "../home/Pipes/filter-labels.pipe";
import { SortPipe } from "../home/Pipes/sort.pipe";

@NgModule({
    declarations:[
        FilterLabelsPipe,
        
    ],

    exports: [
        FilterLabelsPipe,
        
    ]
})

export class SharedModule{
}