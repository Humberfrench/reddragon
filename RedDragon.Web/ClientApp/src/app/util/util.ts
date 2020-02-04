
class Util
{
  constructor() {}

  IsNumeric(val: any): boolean
  {
    return !(val instanceof Array) && (val - parseFloat(val) + 1) >= 0;
  }
};


export {Util}
