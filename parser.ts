class SearchParserAst {
  root?: _Node;
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

class NegationNode implements _Node {
  constructor(v: _Node) {
    this.value = v;
  }

  readonly type: string = "negation";
  value: _Node;
}

class TagNode implements _Node {
  constructor(v: string) {
    this.value = v;
  }

  readonly type = "tag";
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

function parseSearch(text: string) {
  
}

class Token<T = any> {
  constructor(public type: string, public value: T) {}
}

function tokenize(text: string) : Token[] {
  const tokens: Token[] = [];
  let token: Token;

  for ([token, text] = tokenizeNextSymbol(text); token.type != "eof"; [token, text] = tokenizeNextSymbol(text)) {
    tokens.push(token);
  }

  tokens.push(token);
  return tokens;
}

function tokenizeNextSymbol(text: string): [Token, string] {
  if (text.length === 0) {
    return [new Token<void>("eof", undefined), text];
  }

  if (text.startsWith("-")) {
    text = text.replace(/^[- ]+/, ""); // Threat any amount of `[- ]` at the beginning as negation.
    return [new Token<string>("op", "negation"), text];
  }

  let op = "";

  if (text.startsWith(" ")) {
    op = "and";
    text = text.trimStart();
  }

  if (text.startsWith('|')) {
    op = "or";
    text = text.replace(/^[\| ]+/, ""); // Threat any amount of [| ] as or.
  }

  if (text.startsWith("}")) {
    op = "paren_close";
    text = text.substring(1);
  }

  if (op) {
    return [new Token<string>("op", op), text];
  }

  if (text.startsWith("{")) {
    text = text.substring(1);
    text.trimStart();
    return [new Token<string>("op", "paren_open"), text];
  }

  // Nothing else is left, so it must be tag or metatag, at this point we don't care which is which.
  const tagEnd = text.search(/[ \|\}]/); // Search for first space or 'or' or } operator.
  if (tagEnd == -1) {
    return [new Token<string>("tag", text), ""];
  }

  const tag = text.substring(0, tagEnd);
  return [new Token<string>("tag", tag), text.substring(tag.length)];
}

function hasNextSymbol(text: string): boolean {
  return text.trim().length > 0;
} 


console.log(tokenize("-{t1 t2 t3} | {t-4 t5 -t6}"));
