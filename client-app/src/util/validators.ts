export const PASSWORD_MIN_LENGTH = 8;
export const PASSWORD_MAX_LENGTH = 256;

const isNonEmptyString = (val: string) => {
  return typeof val === 'string' && val.trim().length > 0;
};

/**
 * Validator functions and helpers for Final Forms
 */

// Final Form expects and undefined value for a successful validation
const VALID: undefined = undefined;

export const required = (message: string) => (value: any) => {
  if (typeof value === 'undefined' || value === null) {
    // undefined or null values are invalid
    return message;
  }
  if (typeof value === 'string') {
    // string must be nonempty when trimmed
    return isNonEmptyString(value) ? VALID : message;
  }
  return VALID;
};

export const requiredStringNoTrim = (message: string) => (value: any) => {
  return typeof value === 'string' && value.length > 0 ? VALID : message;
};

export const minLength = (message: string, minimumLength: number) => (value: any) => {
  const hasLength = value && typeof value.length === 'number';
  return hasLength && value.length >= minimumLength ? VALID : message;
};

export const maxLength = (message: string, maximumLength: number) => (value: any) => {
  if (!value) {
    return VALID;
  }
  const hasLength = value && typeof value.length === 'number';
  return hasLength && value.length <= maximumLength ? VALID : message;
};

export const nonEmptyArray = (message: string) => (value: any) => {
  return value && Array.isArray(value) && value.length > 0 ? VALID : message;
};

export const bookingDateRequired = (inValidDateMessage: string) => (value: any) => {
  const dateIsValid = value && value.date instanceof Date;
  return !dateIsValid ? inValidDateMessage : VALID;
};

export const bookingDatesRequired = (inValidStartDateMessage: string, inValidEndDateMessage: string) => (value: any) => {
  const startDateIsValid = value && value.startDate instanceof Date;
  const endDateIsValid = value && value.endDate instanceof Date;

  if (!startDateIsValid) {
    return inValidStartDateMessage;
  } else if (!endDateIsValid) {
    return inValidEndDateMessage;
  } else {
    return VALID;
  }
};

// Source: http://www.regular-expressions.info/email.html
// See the link above for an explanation of the tradeoffs.
const EMAIL_RE = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i;

export const emailFormatValid = (message: string) => (value: any) => {
  return value && EMAIL_RE.test(value) ? VALID : message;
};

export const parseNum = (str: string) => {
  const num = Number.parseInt(str, 10);
  return Number.isNaN(num) ? null : num;
};

export const composeValidators = (...validators: any) => (value: any) =>
  validators.reduce((error: any, validator: any) => error || validator(value), VALID);
