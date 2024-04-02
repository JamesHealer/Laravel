export interface SelectLetterTypeDTo{
      refId:number;
      shortName:string;
  }

  export interface SelectPartyTypeDTo{
    refId:number;
    refname1:string;
    refname2:string;
}

export interface IncommingCommunicationDto
{
  mytransid:number;
  searchtag:string;

  description:string;

  filledat:string;

  lettertype:string;

  letterdated:string;

  userDocumentNo:string;
  approvedBy:string;
}


export interface loanPercentageDto
{
  total_count:number|0;
  hajjloan_count:number|0;
  hajjloan_per:number|0;
  socloan_count:number|0;
  socloan_per:number|0;
  finloange_count:number|0;
  consloan_count:number|0;
  finloange_per:number|0;
  consloan_per:number|0;
 

}

export interface dashboardResponseDto
{
  myperiodcode:string;
  myid:number;
  mylabel1:string;
  myvalue1:number;
  mylabel2:string;
  myvalue2:number;

}

