class SearchParserAst {
  root: _Node;
}

interface _Node {
  readonly type: string;
}

interface MetatagValue {
  readonly type: string;
}


class StringMetatagValue implements MetatagValue {
  constructor(v: string) {
    this.value = v;
  }

  type = "string";
  value: string;
}

class ArrayMetatagValue implements MetatagValue {
  constructor(v: string[]) {
    this.value = v;
  }

  type = "array";
  value: string[]
}

class RangeMetatagValue implements MetatagValue {
  constructor(from: string, to: string) {
    this.from = from;
    this.to = to;
  }

  type = "range";
  from: string;
  to: string;
}

class TagNode implements _Node {
  constructor(v: string, negated: boolean) {
    this.value = v;
    this.negated = negated;
  }

  readonly type = "tag";
  negated: boolean;
  value: string;
}

class AndNode implements _Node {
  constructor(v: _Node[]) {
    this.value = v;
  }

  readonly type = "and";
  value: _Node[];
}

class OrNode implements _Node {
  constructor(v: _Node[]) {
    this.value = v;
  }
  
  readonly type = "or";
  value: _Node[];
}

class MetatagFilterNode implements _Node {
  constructor(metatag: string, operation: FilterOperation, value: MetatagValue) {
    this.operation = operation;
    this.value = value;
    this.metatag = metatag;
  }

  readonly type = "metatag_filter";
  metatag: string;
  operation: FilterOperation;
  value: MetatagValue;
}

class AgeFilterNode implements _Node {
  constructor(operation: FilterOperation, from: number, to: number) {
    this.operation = operation;
    this.from = from;
    this.to = to;
  }

  readonly type = "age_filter";
  operation: FilterOperation;
  from: number;
  to: number;
}

class MetatagSortingNode implements _Node {
  constructor(metatag: string, operation: FilterOperation, value: MetatagValue) {
    this.operation = operation;
    this.value = value;
    this.metatag = metatag;
  }

  readonly type = "metatag_sort";
  metatag: string;
  operation: FilterOperation;
  value: MetatagValue;
}

enum FilterOperation {
  Equals,
  GreaterThan,
  GreaterThanOrEqual,
  LessThan,
  LessThanOrEqual
}

function parseSearch(text: string)
{

}
